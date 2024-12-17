﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramMaker
{
    internal class ObjectDiagramService
    {
        static string connectionString = "Server=localhost;Database=diagrammaker;User ID=root;Password=0000;";

        internal static List<(int Id, string Name)> GetObjectCanvaByUserId(int userId)
        {
            var data = new List<(int Id, string Name)>();
            string query = "SELECT object_canva_id, name FROM object_canva WHERE user_id = @user_id";

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

        internal static int CreateNewObjectCanva(string name, int userId)
        {
            string insertQuery = "INSERT INTO object_canva (name, user_id) VALUES (@name, @user_id);";
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

        internal static int CreateNewObject(string objectName , string className, int canvaId)
        {
            string insertQuery = "INSERT INTO object (object_name , class_name, object_canva_id) VALUES (@object_name , @class_name, @object_canva_id);";
            int insertedId;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@object_name", objectName);
                        command.Parameters.AddWithValue("@class_name", className);
                        command.Parameters.AddWithValue("@object_canva_id", canvaId);

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

        internal static List<(int Id, string ObjectName, string ClassName)> GetObjectByCanvaId(int canvaId)
        {
            var data = new List<(int Id, string ObjectName , string ClassName)>();
            string query = "SELECT object_id, object_name ,class_name  FROM object WHERE object_canva_id = @canva_id";

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
                                data.Add((reader.GetInt32(0), reader.GetString(1) , reader.GetString(2)));
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

        internal static void AddObjectAtt(string name, string value, int objectId)
        {
            string insertQuery = "INSERT INTO object_attribute ( name, value ,object_id) VALUES (@name, @value ,@objectId);";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@value", value);
                        command.Parameters.AddWithValue("@objectId", objectId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal static void DelObject(int objectId)
        {
            string insertQuery = "DELETE FROM object_attribute WHERE object_id = @objectId;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@objectId", objectId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            string insertQuery2 = "DELETE FROM links WHERE objectA_id = @objectId OR objectB_id = @objectId;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery2, connection))
                    {
                        command.Parameters.AddWithValue("@objectId", objectId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            string insertQuery3 = "DELETE FROM object WHERE object_id = @objectId;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery3, connection))
                    {
                        command.Parameters.AddWithValue("@objectId", objectId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        internal static void AddLink(int objectId1, int objectId2, String link)
        {
            string insertQuery = "INSERT INTO links (objectA_id , objectB_id, link_text) VALUES (@objectId1 , @objectId2, @link);";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@objectId1", objectId1);
                        command.Parameters.AddWithValue("@objectId2", objectId2);
                        command.Parameters.AddWithValue("@link", link);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal static void DelLink(int objectId1, int objectId2)
        {
            string insertQuery = "DELETE FROM links WHERE objectA_id = @objectId1 and objectB_id = @objectId2;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@objectId1", objectId1);
                        command.Parameters.AddWithValue("@objectId2", objectId2);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        internal static List<(int Id1, string ObjectName1 , string ClassName1, int Id2, string ObjectName2, string ClassName2, String linkText)> GetLinksByCanvaId(int canvaId)
        {
            var data = new List<(int Id1, string ObjectName1, string ClassName1, int Id2, string ObjectName2, string ClassName2, String linkText)>();
            string query =
                """
                SELECT 
                    l.objectA_id, 
                    oa.object_name AS objectA_object_name, 
                    oa.class_name AS objectA_class_name, 
                    l.objectB_id, 
                    ob.object_name AS objectB_object_name, 
                    ob.class_name AS objectB_class_name, 
                    l.link_text
                FROM links l
                JOIN object oa ON l.objectA_id = oa.object_id
                JOIN object ob ON l.objectB_id = ob.object_id
                WHERE oa.object_canva_id = @canva_id;
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
                                data.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
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
    }
}