using Chess.tables;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Chess.db
{
    internal class UsersDB : IDB<Users>
    {
        public void Login(Users u)
        {
            SqlConnection connection = DbConnection.Connect();

            using (SqlCommand command = new SqlCommand("login_user", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@name", u.Name);
                command.Parameters.AddWithValue("@password", u.Password);

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Int);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.ExecuteNonQuery();

                int success = Convert.ToInt32(successParameter.Value);
                if (success == 1)
                {
                    MessageBox.Show("You have successfully logged!", "Successfully logged.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Invalid credentials.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Register(Users u)
        {
            SqlConnection connection = DbConnection.Connect();

            using (SqlCommand command = new SqlCommand("add_user", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@name", u.Name);
                command.Parameters.AddWithValue("@password", u.Password);

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Int);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.ExecuteNonQuery();

                int success = Convert.ToInt32(successParameter.Value);
                if (success == 1)
                {
                    MessageBox.Show("You have been successfully registered!", "Successfully registered.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This username already exists!", "Invalid username.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}