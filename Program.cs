using System.Threading;
using System.Windows.Forms;

namespace Chess
{
    internal static class Program
    {
        static void Main()
        {
            HomeScreen loadScreen = new HomeScreen();
            new Thread(x => Application.Run(loadScreen)).Start();
        }
    }
}