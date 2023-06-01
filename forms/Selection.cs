using Chess.tcp;
using System.Text.RegularExpressions;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Chess.forms
{
    public partial class Selection : Form
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void Host_Click(object sender, EventArgs e)
        {
            Close();

            Game game = null;

            new Thread(() =>
            {
                game = new Game(true);
                Application.Run(game);
            }).Start();

            while (game == null)
                Thread.Sleep(1);

            new Server(game);
        }

        private void Join_Click(object sender, EventArgs e)
        {
            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            MatchCollection result = ip.Matches(IP.Text);
            string address = null;

            if (result.Count > 0)
                address = result[0].Value;
            else if (IP.Text.Equals(""))
                address = "127.0.0.1";
            else
            {
                MessageBox.Show("Invalid IP address!", "Invalid address.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Close();
            Game game = null;

            new Thread(() =>
            {
                game = new Game(false);
                Application.Run(game);
            }).Start();

            while (game == null)
                Thread.Sleep(1);

            new Client(game, address);
        }

    }
}