using System.Configuration;
using System.Data.SqlClient;

namespace Chess.db
{
    public class DbConnection
    {
        private static SqlConnection Instance = null;

        private DbConnection()
        {
        }

        public static SqlConnection Connect()
        {
            if (Instance == null)
            {
                SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                consStringBuilder.UserID = ReadSetting("User");
                consStringBuilder.Password = ReadSetting("Pass");
                consStringBuilder.InitialCatalog = ReadSetting("Catalog");
                consStringBuilder.DataSource = ReadSetting("Source");
                Instance = new SqlConnection(consStringBuilder.ConnectionString);
                Instance.Open();
            }

            return Instance;
        }

        public static void CloseConnection()
        {
            try
            {
                if (Instance != null)
                {
                    Instance.Close();
                    Instance.Dispose();
                }
            }
            catch
            {
            }
            finally
            {
                Instance = null;
            }
        }

        private static string ReadSetting(string key)
        {
            var AppConfig = ConfigurationManager.AppSettings;
            string result = AppConfig[key];
            return result;
        }

    }
}