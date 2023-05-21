using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Chess.forms;
using Chess.db;

namespace Chess.tcp
{
    internal class Server
    {
        private const int serverPort = 2459;
        private TcpClient connectedClient;
        NetworkStream networkStream;
        Game game;

        public Server(Game game)
        {
            this.game = game;
            Start();
        }

        private void Start()
        {
            Task.Run(async () =>
            {
                await FindClient();
                await SetNames();
            });
        }

        private async Task FindClient()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, serverPort);
            tcpListener.Start();
            connectedClient = await tcpListener.AcceptTcpClientAsync();
            tcpListener.Stop();
        }

        private async Task SetNames()
        {
            networkStream = connectedClient.GetStream();

            byte[] clientName = new byte[1024];
            int bytesRead = await networkStream.ReadAsync(clientName, 0, clientName.Length);
            string client = Encoding.UTF8.GetString(clientName, 0, bytesRead);

            byte[] serverName = Encoding.UTF8.GetBytes(UsersDB.username);
            await networkStream.WriteAsync(serverName, 0, serverName.Length);

            game.SetupNames(client, UsersDB.username);
        }

        /*private async Task CommunicateWithClient()
        {
            while (true)
            {
                string message = "sr";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await networkStream.WriteAsync(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                await Task.Delay(1000);
            }

            networkStream.Close();
            connectedClient.Close();
        }*/

    }
}