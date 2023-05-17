﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Chess.forms
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            ResizeComponents();
        }

        private void HomeScreen_Resize(object sender, EventArgs e)
        {
            if(!(WindowState == FormWindowState.Minimized))
            {
                ResizeComponents();
            }
        }

        private void ResizeComponents()
        {
            int width = this.ClientSize.Width / 4;
            int height = this.ClientSize.Height / 8;
            int widthTitle = this.ClientSize.Width;
            int heightTitle = this.ClientSize.Height / 2;

            Login.Size = new Size(width, height);
            Register.Size = new Size(width, height);
            Title.Size = new Size(widthTitle, heightTitle);

            Font buttonFont = new Font("Segoe UI Emoji", width / 10, FontStyle.Regular);
            Login.Font = buttonFont;
            Register.Font = buttonFont;

            Font titleFont = new Font("Yu Gothic UI", width / 4, FontStyle.Regular);
            Title.Font = titleFont;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Hide();
            Login logScreen = new Login();

            Thread thread = new Thread(() => Application.Run(logScreen));

            thread.Start();
            thread.Join();

            Show();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Hide();
            Register regScreen = new Register();

            Thread thread = new Thread(() => Application.Run(regScreen));

            thread.Start();
            thread.Join();

            Show();
        }

    }
}