using Chess.tcp;
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

        private void Host_Click(object sender, System.EventArgs e)
        {
            Close();
            Game game = null;

            new Thread(() =>
            {
                game = new Game();
                Application.Run(game);
            }).Start();

            while (game == null)
                Thread.Sleep(1);

            new Server(game);
        }

        private void Join_Click(object sender, System.EventArgs e)
        {
            Close();
            Game game = null;

            new Thread(() =>
            {
                game = new Game();
                Application.Run(game);
            }).Start();

            while (game == null)
                Thread.Sleep(1);

            new Client(game);
        }

    }
}