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

        internal static List<(int Id, string Name)> GetClassByCanvaId(int canvaId)
        {
            var data = new List<(int Id, string Name)>();
            string query = "SELECT class_id, name FROM class WHERE class_canva_id = @canva_id";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@canva_id", canvaId);
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

        internal static List<(int Id1 , string Name1,int Id2, string Name2 , int relationshipId)> GetRelationshipByCanvaId(int canvaId)
        {
            var data = new List<(int Id1, string Name1, int Id2, string Name2, int relationshipId)>();
            string query =
                """
                SELECT 
                    r.classA_id, 
                    ca.name AS classA_name, 
                    r.classB_id, 
                    cb.name AS classB_name, 
                    r.relationship_type
                FROM relationship r
                JOIN class ca ON r.classA_id = ca.class_id
                JOIN class cb ON r.classB_id = cb.class_id
                WHERE ca.class_canva_id = @canva_id;
                """;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@canva_id", canvaId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                data.Add((reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4)));
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

        internal static void DelClass(int classId)
        {
            string insertQuery = "DELETE FROM class_attribute WHERE class_id = @classId;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@classId", classId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            string insertQuery2 = "DELETE FROM class_method WHERE class_id = @classId;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery2, connection))
                    {
                        command.Parameters.AddWithValue("@classId", classId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            string insertQuery3 = "DELETE FROM class WHERE class_id = @classId;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery3, connection))
                    {
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

        internal static void DelRelationship(int classId1 , int classId2)
        {
            string insertQuery = "DELETE FROM relationship WHERE classA_id = @classId1 and classB_id = @classId2;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@classId1", classId1);
                        command.Parameters.AddWithValue("@classId2", classId2);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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

        internal static void AddClassMethod(string modifiers, string name,string parameter, string returnType, int classId)
        {
            string insertQuery = "INSERT INTO class_method (modifiers , name,parameter ,return_type ,class_id) VALUES (@modifiers , @name,@parameter, @returnType ,@classId);";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@modifiers", modifiers);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@parameter", parameter);
                        command.Parameters.AddWithValue("@returnType", returnType);
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

        internal static void AddRelationship(int classId1, int classId2 , int relationshipId)
        {
            string insertQuery = "INSERT INTO relationship (classA_id , classB_id, relationship_type) VALUES (@classA_id , @classB_id, @relationship_type);";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@classA_id", classId1);
                        command.Parameters.AddWithValue("@classB_id", classId2);
                        command.Parameters.AddWithValue("@relationship_type", relationshipId);

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
