using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.tcp
{
    internal class Server
    {
        private const int serverPort = 2459;
        private TcpListener tcpListener;
        private TcpClient connectedClient;

        public Server()
        {
            Start();
        }

        private async void Start()
        {
            tcpListener = new TcpListener(IPAddress.Any, serverPort);
            tcpListener.Start();

            connectedClient = await tcpListener.AcceptTcpClientAsync();

            await ReceiveData();

            tcpListener.Stop();
        }

        private async Task ReceiveData()
        {
            NetworkStream networkStream = connectedClient.GetStream();

            while (true)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    break;
                }

                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                MessageBox.Show("Response: " + receivedData);

                string response = "Data.";
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                await networkStream.WriteAsync(responseData, 0, responseData.Length);
            }

            connectedClient.Close();
        }

    }
}