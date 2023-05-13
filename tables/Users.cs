using System.Windows.Forms;

namespace Chess.tables
{
    internal class Users
    {
        private string _name;
        private string _password;

        public string Name { get => _password; set => _password = value; }
        public string Password
        {
            get
            { 
                return _name;
            }
            set
            {
                if (value.Length >= 5)
                {
                    _name = value;
                }
                else
                {
                    MessageBox.Show("Minimal length for password is 5 characters!", "Invalid password.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public Users(string name, string pass)
        {
            Name = name;
            Password = pass;
        }

    }
}