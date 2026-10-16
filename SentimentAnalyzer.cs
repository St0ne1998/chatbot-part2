namespace CybersecurityBot
{
    public enum Sentiment
    {
        Neutral,
        Worried,
        Curious,
        Frustrated
    }

    public static class SentimentAnalyzer
    {
        public static Sentiment Analyze(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("worried") || lowerInput.Contains("scared") || lowerInput.Contains("afraid") || lowerInput.Contains("panic") || lowerInput.Contains("hacked"))
            {
                return Sentiment.Worried;
            }
            if (lowerInput.Contains("frustrated") || lowerInput.Contains("annoyed") || lowerInput.Contains("confused") || lowerInput.Contains("stuck") || lowerInput.Contains("hard"))
            {
                return Sentiment.Frustrated;
            }
            if (lowerInput.Contains("curious") || lowerInput.Contains("wondering") || lowerInput.Contains("how") || lowerInput.Contains("what") || lowerInput.Contains("tell me"))
            {
                return Sentiment.Curious;
            }

            return Sentiment.Neutral;
        }

        public static string GetEmpatheticPrefix(Sentiment sentiment)
        {
            return sentiment switch
            {
                Sentiment.Worried => "It's completely understandable to feel that way about online security threats. Let's tackle this step-by-step to keep you safe.\n\n",
                Sentiment.Frustrated => "I understand that cybersecurity can be overwhelming at times. Take a deep breath; I'm here to help make it simple.\n\n",
                Sentiment.Curious => "That's a fantastic inquiry! Let's explore the details together.\n\n",
                _ => ""
            };
        }
    }
}