using System.Collections.Generic;

namespace CybersecurityBot
{
    public class MemoryManager
    {
        private readonly List<string> _userInterests = new List<string>();
        private string _userName = string.Empty;

        public void SetUserName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                _userName = name.Trim();
            }
        }

        public string GetUserName() => _userName;
        public bool HasName() => !string.IsNullOrEmpty(_userName);

        public void RememberInterest(string topic)
        {
            if (!_userInterests.Contains(topic))
            {
                _userInterests.Add(topic);
            }
        }

        public string RecallMemories()
        {
            string namePart = HasName() ? $" {_userName}" : "";
            if (_userInterests.Count == 0)
            {
                return $"I don't have any specific preferences recorded for you yet{namePart}. Tell me what cybersecurity topics you care about!";
            }

            return $"I remember{namePart} that you are interested in: {string.Join(", ", _userInterests)}. We can dive deeper into any of these whenever you're ready!";
        }
    }
}