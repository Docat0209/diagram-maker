using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DiagramMaker
{
    internal class ClassDiagramService
    {
        static string connectionString = "Server=localhost;Database=diagrammaker;User ID=root;Password=0000;";
        internal static List<(int Id, string Name)> GetClassCanvaByUserId(int userId)
        {
            var data = new List<(int Id, string Name)>();
            string query = "SELECT class_canva_id, name FROM class_canva WHERE user_id = @user_id";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", userId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                data.Add((reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return data;
        }

        internal static int CreateNewClassCanva(string name , int userId)
        {
            string insertQuery = "INSERT INTO class_canva (name, user_id) VALUES (@name, @user_id);";
            int insertedId;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@user_id", userId);

                        command.ExecuteNonQuery();

                        insertedId = (int)command.LastInsertedId;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return insertedId;
        }

        internal static int CreateNewClass(string name, int canvaId)
        {
            string insertQuery = "INSERT INTO class (name, class_canva_id) VALUES (@name, @class_canva_id);";
            int insertedId;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@class_canva_id", canvaId);

                        command.ExecuteNonQuery();

                        insertedId = (int)command.LastInsertedId;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return insertedId;
        }

        internal static void AddClassAtt(string modifiers , string name, string  dataType ,int classId)
        {
            string insertQuery = "INSERT INTO class_attribute (modifiers , name, data_type ,class_id) VALUES (@modifiers , @name, @dataType ,@classId);";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@modifiers", modifiers);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@dataType", dataType);
                        command.Parameters.AddWithValue("@classId", classId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
