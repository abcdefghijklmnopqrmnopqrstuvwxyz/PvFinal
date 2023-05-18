using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Chess.tcp
{
    internal class Client
    {
        private const int serverPort = 2459;
        private TcpClient tcpClient;

        public Client()
        {
            ConnectToServerAsync();
        }

        private async void ConnectToServerAsync()
        {
            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync("127.0.0.1", serverPort);
            MessageBox.Show("Connected to server.");

            await Task.Delay(1000);

            string message = "Client!";
            byte[] data = Encoding.UTF8.GetBytes(message);
            await tcpClient.GetStream().WriteAsync(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = await tcpClient.GetStream().ReadAsync(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            MessageBox.Show(response);

            tcpClient.Close();
        }

    }
}