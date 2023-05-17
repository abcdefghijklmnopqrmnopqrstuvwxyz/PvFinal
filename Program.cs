using Chess.forms;
using System.Threading;
using System.Windows.Forms;

namespace Chess
{
    internal static class Program
    {
        static void Main()
        {
            Game loadScreen = new Game();
            new Thread(() => Application.Run(loadScreen)).Start();
        }

    }
}