using Chess.db;
using Chess.tables;
using System.Windows.Forms;

namespace Chess.forms
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Regbutton_Click(object sender, System.EventArgs e)
        {
            if (Nameinput.Text.Length > 0 && Passinput.Text.Length >= 5)
            {
                new UsersDB().Register(new Users(Nameinput.Text, Passinput.Text));
                Dispose();
            }
            else
            {
                MessageBox.Show("Minimal length for username is 1 cahracter and for password 5 characters!", "Register error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nameinput_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}