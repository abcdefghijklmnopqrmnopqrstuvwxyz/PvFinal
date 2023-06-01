using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Chess.db;
using Chess.forms;

namespace Chess.tcp
{
    internal class Client : GameConnection
    {
        public static string message = null;
        private const int serverPort = 2459;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private readonly Game game;
        private readonly string IP;


        public Client(Game game, string IP)
        {
            this.IP = IP;
            this.game = game;
            Start();
        }

        protected override void Start()
        {
            Task.Run(async () =>
            {
                await FindOpponent();
                await SetNames();
                await Communicate();
            });
        }

        protected override async Task FindOpponent()
        {
            tcpClient = new TcpClient();
            while (!tcpClient.Connected)
            {
                try
                {
                    await tcpClient.ConnectAsync(IP, serverPort);
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }
        }

        protected override async Task SetNames()
        {
            networkStream = tcpClient.GetStream();

            byte[] clientName = Encoding.UTF8.GetBytes(UsersDB.username);
            await networkStream.WriteAsync(clientName, 0, clientName.Length);

            byte[] serverName = new byte[1024];
            int bytesRead = await networkStream.ReadAsync(serverName, 0, serverName.Length);
            string server = Encoding.UTF8.GetString(serverName, 0, bytesRead);

            game.SetupNames(UsersDB.username, server);
        }

        protected override async Task Communicate()
        {
            string response;

            while (true)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] parts = response.Split(',');

                game.OpponentMove(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]));

                if (parts.Length > 3)
                {
                    response = parts[3];
                    break;
                }

                Game.IsOnTurn = true;

                while (message == null)
                    await Task.Delay(1);

                Game.IsOnTurn = false;

                byte[] data = Encoding.UTF8.GetBytes(message);
                await networkStream.WriteAsync(data, 0, data.Length);
                string[] mess = message.Split(',');

                if (mess.Length > 3)
                {
                    response = mess[3];
                    break;
                }

                message = null;
            }

            networkStream.Close();
            tcpClient.Close();
            Exit(game, response);
        }

    }
}