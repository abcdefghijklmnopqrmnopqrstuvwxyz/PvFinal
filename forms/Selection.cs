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
            Dispose();
            Game game = new Game();
            new Thread(() => Application.Run(game)).Start();
            Server server = new Server(game);
        }

        private void Join_Click(object sender, System.EventArgs e)
        {
            Dispose();
            Game game = new Game();
            new Thread(() => Application.Run(game)).Start();
            Client client = new Client(game);
        }

    }
}