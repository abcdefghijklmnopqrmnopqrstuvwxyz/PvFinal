using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Chess.forms;
using Chess.db;
using System;

namespace Chess.tcp
{
    internal class Server : GameConnection
    {
        public static string message = null;
        private const int serverPort = 2459;
        private TcpClient connectedClient;
        private NetworkStream networkStream;
        private readonly Game game;

        public Server(Game game)
        {
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
            TcpListener tcpListener = new TcpListener(IPAddress.Any, serverPort);
            tcpListener.Start();
            connectedClient = await tcpListener.AcceptTcpClientAsync();
            tcpListener.Stop();
        }

        protected override async Task SetNames()
        {
            networkStream = connectedClient.GetStream();

            byte[] clientName = new byte[1024];
            int bytesRead = await networkStream.ReadAsync(clientName, 0, clientName.Length);
            string client = Encoding.UTF8.GetString(clientName, 0, bytesRead);

            byte[] serverName = Encoding.UTF8.GetBytes(UsersDB.username);
            await networkStream.WriteAsync(serverName, 0, serverName.Length);

            game.SetupNames(client, UsersDB.username);
            Game.IsOnTurn = true;
        }

        protected override async Task Communicate()
        {
            string response;

            while (true)
            {
                while (message == null)
                    await Task.Delay(1);

                Game.IsOnTurn = false;

                byte[] data = Encoding.UTF8.GetBytes(message);
                await networkStream.WriteAsync(data, 0, data.Length);
                string[] mess = message.Split(',');

                if (mess.Length > 3)
                    if (mess[3].Equals("black") || mess[3].Equals("white"))
                    {
                        response = mess[3];
                        break;
                    }

                message = null;
                
                byte[] buffer = new byte[1024];
                int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] parts = response.Split(',');

                game.OpponentMove(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]));

                if (mess.Length > 3)
                    if (parts[3].Equals("black") || parts[3].Equals("white"))
                        break;

                Game.IsOnTurn = true;
            }

            networkStream.Close();
            connectedClient.Close();
            Exit(game, response);
        }

    }
}