using Chess.tcp;
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
            new Server();
        }

        private void Join_Click(object sender, System.EventArgs e)
        {
            new Client();
        }

    }
}