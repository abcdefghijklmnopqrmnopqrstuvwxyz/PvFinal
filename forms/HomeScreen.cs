using Chess.db;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Chess.forms
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void HomeScreen_Load(object sender, System.EventArgs e)
        {
            ResizeComponents();
        }

        private void HomeScreen_Resize(object sender, System.EventArgs e)
        {
            if(!(WindowState == FormWindowState.Minimized))
                ResizeComponents();
        }

        /// <summary>
        /// Resizes components of 'HomeScreen' form.
        /// </summary>
        private void ResizeComponents()
        {
            int width = this.ClientSize.Width / 4;
            int height = this.ClientSize.Height / 8;
            int widthTitle = this.ClientSize.Width;
            int heightTitle = this.ClientSize.Height / 2;

            Login.Size = new Size(width, height);
            Register.Size = new Size(width, height);
            Title.Size = new Size(widthTitle, heightTitle);

            Font buttonFont = new Font("Segoe UI Emoji", width / 10, FontStyle.Regular);
            Login.Font = buttonFont;
            Register.Font = buttonFont;

            Font titleFont = new Font("Yu Gothic UI", width / 4, FontStyle.Regular);
            Title.Font = titleFont;
        }

        /// <summary>
        /// Opens 'Login' form. If successfully logged, opens 'Selection' form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, System.EventArgs e)
        {
            Hide();
            Thread thread = new Thread(() => Application.Run(new Login()));

            thread.Start();
            thread.Join();

            if (UsersDB.logged)
            {
                Close();
                new Thread(() => Application.Run(new Selection())).Start();
            }
            else
                Show();
        }

        /// <summary>
        /// Opens registration form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Click(object sender, System.EventArgs e)
        {
            Hide();
            Thread thread = new Thread(() => Application.Run(new Register()));

            thread.Start();
            thread.Join();

            Show();
        }

    }
}