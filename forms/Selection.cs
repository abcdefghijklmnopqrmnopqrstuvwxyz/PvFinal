using System.Text.RegularExpressions;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Chess.forms
{
    public partial class Selection : Form
    {
        Game game;

        public Selection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens new game instance as server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Host_Click(object sender, EventArgs e)
        {
            Close();

            new Thread(() =>
            {
                game = new Game();
                Application.Run(game);
            }).Start();
        }

        /// <summary>
        /// Opens new game instance as client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Join_Click(object sender, EventArgs e)
        {
            string address = CheckAddress();

            if (address == null)
            {
                MessageBox.Show("Invalid IP address!", "Invalid address.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Close();

            new Thread(() =>
            {
                game = new Game(address);
                Application.Run(game);
            }).Start();
        }

        /// <summary>
        /// Check if input IP address is valid. If input is empty, return localhost IP.
        /// </summary>
        /// <returns>IP address</returns>
        private string CheckAddress()
        {
            Regex ip = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            MatchCollection result = ip.Matches(IP.Text);

            if (result.Count > 0)
                return result[0].Value;
            else if (IP.Text.Equals(""))
                return "127.0.0.1";
            else
                return null;
        }

    }
}