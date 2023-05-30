using Chess.forms;
using System.Threading;
using System.Windows.Forms;

namespace Chess
{
    internal static class Program
    {
        static void Main()
        {
            new Thread(() => Application.Run(new HomeScreen())).Start();
        }

    }
}