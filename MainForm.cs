using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CybersecurityBot
{
    public class MainForm : Form
    {
        private TextBox txtInput;
        private RichTextBox txtChatHistory;
        private RoundedButton btnSend;
        private ChatBotEngine _botEngine;

        public MainForm()
        {
            _botEngine = new ChatBotEngine();
            InitializeComponent();
            InitializeChatSession();
        }

        private void InitializeComponent()
        {
            this.Text = "CybersecurityBot (WEchat) | Amusement Lubisi (st10500573)";
            this.Size = new Size(880, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // ==========================================
            // 1. TOP HEADER PANEL (Crisp White with Red Accent)
            // ==========================================
            Panel pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 150;
            pnlHeader.BackColor = Color.White;
            pnlHeader.Padding = new Padding(10);

            // Large, highly visible ASCII Logo
            Label lblAsciiBanner = new Label();
            lblAsciiBanner.Text = 
                @" __        _______    ____ _   _    _ _____   ____   ___ _____ " + "\n" +
                @" \ \      / / ____|  / ___| | | |  / \_   _| | __ ) / _ \_   _|" + "\n" +
                @"  \ \ /\"" / /|  _|   | |   | |_| | / _ \| |   |  _ \| | | || |  " + "\n" +
                @"   \ V  V / | |___  | |___|  _  |/ ___ \ |   | |_) | |_| || |  " + "\n" +
                @"    \_/\_/  |_____|  \____|_| |_/_/   \_\_|   |____/ \___/ |_|  ";
            
            lblAsciiBanner.Font = new Font("Consolas", 11f, FontStyle.Bold);
            lblAsciiBanner.ForeColor = Color.FromArgb(192, 0, 0); // Deep Crimson Red
            lblAsciiBanner.Dock = DockStyle.Fill;
            lblAsciiBanner.TextAlign = ContentAlignment.MiddleCenter;
            pnlHeader.Controls.Add(lblAsciiBanner);

            // Red Divider Line under Header
            Panel pnlRedDivider = new Panel();
            pnlRedDivider.Dock = DockStyle.Bottom;
            pnlRedDivider.Height = 4;
            pnlRedDivider.BackColor = Color.FromArgb(192, 0, 0);
            pnlHeader.Controls.Add(pnlRedDivider);

            // ==========================================
            // 2. CHAT DISPLAY AREA (RichTextBox)
            // ==========================================
            txtChatHistory = new RichTextBox();
            txtChatHistory.Dock = DockStyle.Fill;
            txtChatHistory.Font = new Font("Segoe UI", 11f);
            txtChatHistory.BackColor = Color.FromArgb(250, 250, 250);
            txtChatHistory.ReadOnly = true;
            txtChatHistory.BorderStyle = BorderStyle.None;

            // Padding Container for Chat Area
            Panel pnlCenter = new Panel();
            pnlCenter.Dock = DockStyle.Fill;
            pnlCenter.Padding = new Padding(20);
            pnlCenter.BackColor = Color.White;
            pnlCenter.Controls.Add(txtChatHistory);

            // ==========================================
            // 3. BOTTOM INPUT PANEL
            // ==========================================
            Panel pnlBottom = new Panel();
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 85;
            pnlBottom.BackColor = Color.FromArgb(245, 245, 245);

            // Input TextBox Container (White box with subtle border)
            Panel pnlInputBox = new Panel();
            pnlInputBox.Location = new Point(25, 20);
            pnlInputBox.Size = new Size(670, 42);
            pnlInputBox.BackColor = Color.White;
            pnlInputBox.BorderStyle = BorderStyle.FixedSingle;

            txtInput = new TextBox();
            txtInput.Font = new Font("Segoe UI", 12f);
            txtInput.BorderStyle = BorderStyle.None;
            txtInput.Location = new Point(10, 8);
            txtInput.Size = new Size(648, 26);
            txtInput.KeyDown += TxtInput_KeyDown;
            pnlInputBox.Controls.Add(txtInput);

            // Round Box "Send" Button
            btnSend = new RoundedButton();
            btnSend.Text = "Send";
            btnSend.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            btnSend.BackColor = Color.FromArgb(192, 0, 0); // Crimson Red
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(715, 18);
            btnSend.Size = new Size(110, 46);
            btnSend.Cursor = Cursors.Hand;
            btnSend.Click += BtnSend_Click;

            pnlBottom.Controls.Add(pnlInputBox);
            pnlBottom.Controls.Add(btnSend);

            // Assemble Form
            this.Controls.Add(pnlCenter);
            this.Controls.Add(pnlBottom);
            this.Controls.Add(pnlHeader);
        }

        private void InitializeChatSession()
        {
            // Trigger voice greeting from Part 1 integration
            AudioPlayer.PlayVoiceGreeting("greeting.wav");

            // Initial greeting and name prompt
            AppendMessage("WEchat Bot", "Welcome to WEchat Cybersecurity Assistant! Before we begin, may I please have your name?", Color.FromArgb(192, 0, 0));
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            ProcessUserMessage();
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ProcessUserMessage();
            }
        }

        private void ProcessUserMessage()
        {
            string userInput = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(userInput)) return;

            AppendMessage("You", userInput, Color.FromArgb(40, 40, 40));
            txtInput.Clear();

            string botResponse = _botEngine.ProcessMessage(userInput);
            AppendMessage("WEchat Bot", botResponse, Color.FromArgb(192, 0, 0));
        }

        private void AppendMessage(string sender, string message, Color color)
        {
            txtChatHistory.SelectionStart = txtChatHistory.TextLength;
            txtChatHistory.SelectionLength = 0;
            txtChatHistory.SelectionColor = color;
            txtChatHistory.SelectionFont = new Font("Segoe UI", 11f, FontStyle.Bold);
            txtChatHistory.AppendText(sender + ": ");

            txtChatHistory.SelectionColor = Color.FromArgb(30, 30, 30);
            txtChatHistory.SelectionFont = new Font("Segoe UI", 11f, FontStyle.Regular);
            txtChatHistory.AppendText(message + "\n\n");

            txtChatHistory.ScrollToCaret();
        }
    }

    // ==========================================
    // CUSTOM ROUNDED BUTTON CLASS FOR THE SEND BUTTON
    // ==========================================
    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 25; // Controls roundness

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rect = new RectangleF(0, 0, this.Width, this.Height);
            GraphicsPath path = GetRoundedPath(rect, BorderRadius);

            this.Region = new Region(path);

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }

            TextRenderer.DrawText(
                pevent.Graphics, 
                this.Text, 
                this.Font, 
                this.ClientRectangle, 
                this.ForeColor, 
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}