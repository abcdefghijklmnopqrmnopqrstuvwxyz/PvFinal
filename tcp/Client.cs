using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Chess.db;
using Chess.forms;

namespace Chess.tcp
{
    internal class Client 
    {
        private const int serverPort = 2459;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        readonly Game game;

        public Client(Game game)
        {
            this.game = game;
            Start();
        }

        private void Start()
        {
            Task.Run(async () =>
            {
                await FindServer();
                await SetNames();
            });
        }

        private async Task FindServer()
        {
            tcpClient = new TcpClient();
            while (!tcpClient.Connected)
            {
                try
                {
                    await tcpClient.ConnectAsync("127.0.0.1", serverPort);
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }
        }

        private async Task SetNames()
        {
            networkStream = tcpClient.GetStream();

            byte[] clientName = Encoding.UTF8.GetBytes(UsersDB.username);
            await networkStream.WriteAsync(clientName, 0, clientName.Length);

            byte[] serverName = new byte[1024];
            int bytesRead = await networkStream.ReadAsync(serverName, 0, serverName.Length);
            string server = Encoding.UTF8.GetString(serverName, 0, bytesRead);

            game.SetupNames(UsersDB.username, server);
        }

        /*private async Task CommunicateWithServer()
        {
            while (true)
            {
                string message = "cl";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await networkStream.WriteAsync(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                await Task.Delay(1000);
            }

            networkStream.Close();
            tcpClient.Close();
        }*/

    }
}