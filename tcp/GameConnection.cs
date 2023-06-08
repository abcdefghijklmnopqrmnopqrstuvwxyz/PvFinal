using Chess.forms;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.tcp
{
    internal abstract class GameConnection
    {
        /*
         * This class contains template for 'Client' and 'Server' classes.
         */

        /// <summary>
        /// Port for client-server communication.
        /// </summary>
        protected const int serverPort = 2459;

        /// <summary>
        /// Starts the client/server on background so other processes can work as UI.
        /// </summary>
        protected abstract void Start();

        /// <summary>
        /// Searches for the clinet/server with specified IP. Lopps until client/server is found.
        /// </summary>
        /// <returns>Null</returns>
        protected abstract Task FindOpponent();

        /// <summary>
        /// Setups names of both players into form after client-server connection is established.
        /// </summary>
        /// <returns>Null</returns>
        protected abstract Task SetNames();

        /// <summary>
        /// Communication between client/server and client. Loops until gets message containing either 'black' or 'white'. 
        /// Interacts with form and visualise moves recived from client/server.
        /// </summary>
        /// <returns>Null</returns>
        protected abstract Task Communicate();

        /// <summary>
        /// Exits the game and shows the winenr.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="response"></param>
        protected void Exit(Game game, string response)
        {
            DialogResult result = new DialogResult();

            if (response.Equals("black"))
                result = MessageBox.Show("Black has won the game!", "Game over.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (response.Equals("white"))
                result = MessageBox.Show("White has won the game!", "Game over.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
                game.Close();
        }

    }
}