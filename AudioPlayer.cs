using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace CybersecurityBot
{
    public static class AudioPlayer
    {
        public static void PlayVoiceGreeting(string filePath)
        {
            try
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

                if (File.Exists(fullPath))
                {
                    using (SoundPlayer player = new SoundPlayer(fullPath))
                    {
                        player.Play(); // Or player.PlaySync(); to test blocking playback
                    }
                }
                else
                {
                    MessageBox.Show($"Audio file not found at: {fullPath}", "Audio Warning");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Audio playback error: {ex.Message}", "Audio Error");
            }
        }
    }
}