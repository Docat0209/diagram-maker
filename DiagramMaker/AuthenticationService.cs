using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramMaker
{
    internal class AuthenticationService
    {
        static string connectionString = "Server=localhost;Database=diagrammaker;User ID=root;Password=0000;";

        internal static int? AuthenticateUser(string account, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT user_id FROM user WHERE account = @account AND password = @password LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@account", account);
                        command.Parameters.AddWithValue("@password", password);

                        object result = command.ExecuteScalar();

                        return result != null ? Convert.ToInt32(result) : (int?)null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("發生錯誤: " + ex.Message);
                    return null;
                }
            }
        }

        internal static bool RegisterUser(string account, string password, string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM user WHERE account = @account";
                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@account", account);
                        int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (userCount > 0)
                        {
                            return false;
                        }
                    }

                    string insertQuery = "INSERT INTO user (account, password, name) VALUES (@account, @password, @name)";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@account", account);
                        insertCommand.Parameters.AddWithValue("@password", password);
                        insertCommand.Parameters.AddWithValue("@name", name);

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
