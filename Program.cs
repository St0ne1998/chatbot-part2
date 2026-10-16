using System;
using System.Windows.Forms;

namespace CybersecurityBot
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "CybersecurityBot Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}