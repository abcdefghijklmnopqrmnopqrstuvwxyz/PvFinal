using Chess.forms;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.tcp
{
    internal abstract class GameConnection
    {
        protected abstract void Start();

        protected abstract Task FindOpponent();

        protected abstract Task SetNames();

        protected abstract Task Communicate();

        protected void Exit(Game game, string response)
        {
            DialogResult result;

            if (response.Equals("black"))
                result = MessageBox.Show("Black has won the game!", "Game over.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                result = MessageBox.Show("White has won the game!", "Game over.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
                game.Close();
        }

    }
}