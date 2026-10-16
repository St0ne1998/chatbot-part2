using System;
using System.Collections.Generic;

namespace CybersecurityBot
{
    public class ChatBotEngine
    {
        private readonly Dictionary<string, List<string>> _knowledgeBase;
        private readonly Random _random = new Random();
        public MemoryManager Memory { get; } = new MemoryManager();
        private string _lastTopic = string.Empty;

        // Multi-step startup state machine flags
        private enum SetupState { AskingName, AskingAge, Completed }
        private SetupState _setupState = SetupState.AskingName;

        private string _tempName = string.Empty;

        public ChatBotEngine()
        {
            _knowledgeBase = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "password", new List<string>
                    {
                        "Make sure to use strong, unique passwords for each online account. Avoid using personal details like birthdays.",
                        "Consider using a trusted password manager to generate and securely store complex passphrases.",
                        "A robust password should be at least 12 characters long, combining uppercase letters, numbers, and symbols."
                    }
                },
                {
                    "phishing", new List<string>
                    {
                        "Be cautious of unsolicited emails or text messages asking for personal information or credentials. Scammers often impersonate trusted institutions.",
                        "Always verify the sender's email address and avoid clicking suspicious links or downloading unexpected attachments.",
                        "If an offer or alert feels too good or too urgent to be true, it is likely a phishing attempt."
                    }
                },
                {
                    "privacy", new List<string>
                    {
                        "Review your social media and application privacy settings regularly to limit what personal data is publicly visible.",
                        "Be mindful of what you share online; digital footprints can persist for years.",
                        "Use encrypted messaging apps and secure browsers to safeguard your day-to-day communications."
                    }
                },
                {
                    "malware", new List<string>
                    {
                        "Keep your operating system, browsers, and antivirus software updated to patch known security vulnerabilities.",
                        "Never download software or files from untrusted or unverified third-party websites.",
                        "Regularly back up your important files to an external drive or secure cloud storage to protect against ransomware."
                    }
                }
            };
        }

        public string ProcessMessage(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "Please type a message or ask a cybersecurity question!";
            }

            // Step 1: Handle Name Gathering
            if (_setupState == SetupState.AskingName)
            {
                _tempName = userInput.Trim();
                Memory.SetUserName(_tempName);
                _setupState = SetupState.AskingAge;
                return $"Pleased to meet you, {_tempName}! How old are you?";
            }

            // Step 2: Handle Age Gathering
            if (_setupState == SetupState.AskingAge)
            {
                _setupState = SetupState.Completed;
                return "Got it! Thanks for sharing. Now that I know a bit about you, what cybersecurity topic would you like to explore? (e.g., passwords, phishing, privacy, malware) and what do i remember";
            }

            // Sentiment Detection for normal conversation
            Sentiment sentiment = SentimentAnalyzer.Analyze(userInput);
            string prefix = SentimentAnalyzer.GetEmpatheticPrefix(sentiment);
            string lowerInput = userInput.ToLower();

            // Follow-up handler
            if (lowerInput.Contains("another tip") || lowerInput.Contains("tell me more") || lowerInput.Contains("explain more") || lowerInput.Contains("more"))
            {
                if (!string.IsNullOrEmpty(_lastTopic) && _knowledgeBase.ContainsKey(_lastTopic))
                {
                    return prefix + GetRandomResponse(_lastTopic) + $"\n\n(Follow-up for {_userNameSafe()}, topic: {_lastTopic})";
                }
                return prefix + $"We haven't discussed a specific topic yet, {_userNameSafe()}. Try asking about passwords, phishing, privacy, or malware!";
            }

            // Memory recall handler
            if (lowerInput.Contains("what do you remember") || lowerInput.Contains("my memory") || lowerInput.Contains("recall"))
            {
                return prefix + Memory.RecallMemories();
            }

            // Keyword Matching & Interest Memory Logging
            foreach (var kvp in _knowledgeBase)
            {
                if (lowerInput.Contains(kvp.Key))
                {
                    _lastTopic = kvp.Key;
                    Memory.RememberInterest(kvp.Key);
                    return prefix + GetRandomResponse(kvp.Key);
                }
            }

            // Fallback response for unrecognised inputs
            return prefix + $"I'm not entirely sure I understand your query, {_userNameSafe()}. You can ask me about passwords, phishing, privacy, malware, or type 'what do you remember'.";
        }

        private string GetRandomResponse(string topic)
        {
            List<string> responses = _knowledgeBase[topic];
            return responses[_random.Next(responses.Count)];
        }

        private string _userNameSafe()
        {
            return Memory.HasName() ? Memory.GetUserName() : "friend";
        }
    }
}