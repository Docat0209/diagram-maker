using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

            string insertQuery3 = "DELETE FROM relationship WHERE classA_id = @classId OR classB_id = @classId;";

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

            string insertQuery4 = "DELETE FROM class WHERE class_id = @classId;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery4, connection))
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

        internal static void AddRelationship(int classId1, int classId2, int relationshipId)
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


        // 以下都是提取
        public class ClassModel
        {
            public int ClassId { get; set; }
            public string Name { get; set; }
            public int ClassCanvaId { get; set; }
        }

        internal static List<ClassModel> GetClass()
        {
            string selectQuery = "SELECT class_id, name, class_canva_id FROM class;";
            List<ClassModel> classes = new List<ClassModel>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClassModel classModel = new ClassModel
                                {
                                    ClassId = reader.GetInt32("class_id"),
                                    Name = reader.GetString("name"),
                                    ClassCanvaId = reader.GetInt32("class_canva_id")
                                };
                                classes.Add(classModel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return classes;
        }
        

        // 假設的 UserModel 類別
        public class UserModel
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Account { get; set; }
            public string Password { get; set; }
        }

        internal static List<UserModel> GetUsers()
        {
            string selectQuery = "SELECT user_id, name, account, password FROM user;";
            List<UserModel> users = new List<UserModel>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserModel user = new UserModel
                                {
                                    UserId = reader.GetInt32("user_id"),
                                    Name = reader.GetString("name"),
                                    Account = reader.GetString("account"),
                                    Password = reader.GetString("password")
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return users;
        }

        // 假設的 ClassCanvaModel 類別
        public class ClassCanvaModel
        {
            public int ClassCanvaId { get; set; }
            public string Name { get; set; }
            public int UserId { get; set; }
        }

        internal static List<ClassCanvaModel> GetClassCanvas()
        {
            string selectQuery = "SELECT class_canva_id, name, user_id FROM class_canva;";
            List<ClassCanvaModel> classCanvas = new List<ClassCanvaModel>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClassCanvaModel classCanva = new ClassCanvaModel
                                {
                                    ClassCanvaId = reader.GetInt32("class_canva_id"),
                                    Name = reader.GetString("name"),
                                    UserId = reader.GetInt32("user_id")
                                };
                                classCanvas.Add(classCanva);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return classCanvas;
        }

        // 假設的 ClassAttributeModel 類別
        public class ClassAttributeModel
        {
            public int ClassAttributeId { get; set; }
            public string Modifiers { get; set; }
            public string Name { get; set; }
            public string DataType { get; set; }
            public int ClassId { get; set; }
        }

        internal static List<ClassAttributeModel> GetClassAttributes()
        {
            string selectQuery = "SELECT class_attribute_id, modifiers, name, data_type, class_id FROM class_attribute;";
            List<ClassAttributeModel> classAttributes = new List<ClassAttributeModel>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClassAttributeModel classAttribute = new ClassAttributeModel
                                {
                                    ClassAttributeId = reader.GetInt32("class_attribute_id"),
                                    Modifiers = reader.GetString("modifiers"),
                                    Name = reader.GetString("name"),
                                    DataType = reader.GetString("data_type"),
                                    ClassId = reader.GetInt32("class_id")
                                };
                                classAttributes.Add(classAttribute);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return classAttributes;
        }

        // 假設的 ClassMethodModel 類別
        public class ClassMethodModel
        {
            public int ClassMethodId { get; set; }
            public string Modifiers { get; set; }
            public string Name { get; set; }
            public string Parameter { get; set; }
            public string ReturnType { get; set; }
            public int ClassId { get; set; }
        }

        internal static List<ClassMethodModel> GetClassMethods()
        {
            string selectQuery = "SELECT class_method_id, modifiers, name, parameter, return_type, class_id FROM class_method;";
            List<ClassMethodModel> classMethods = new List<ClassMethodModel>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClassMethodModel classMethod = new ClassMethodModel
                                {
                                    ClassMethodId = reader.GetInt32("class_method_id"),
                                    Modifiers = reader.GetString("modifiers"),
                                    Name = reader.GetString("name"),
                                    Parameter = reader.IsDBNull("parameter") ? null : reader.GetString("parameter"),
                                    ReturnType = reader.GetString("return_type"),
                                    ClassId = reader.GetInt32("class_id")
                                };
                                classMethods.Add(classMethod);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return classMethods;
        }

        // 假設的 RelationshipModel 類別
        public class RelationshipModel
        {
            public int ClassAId { get; set; }
            public int ClassBId { get; set; }
            public int RelationshipType { get; set; }
        }

        internal static List<RelationshipModel> GetRelationships()
        {
            string selectQuery = "SELECT classA_id, classB_id, relationship_type FROM relationship;";
            List<RelationshipModel> relationships = new List<RelationshipModel>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RelationshipModel relationship = new RelationshipModel
                                {
                                    ClassAId = reader.GetInt32("classA_id"),
                                    ClassBId = reader.GetInt32("classB_id"),
                                    RelationshipType = reader.GetInt32("relationship_type")
                                };
                                relationships.Add(relationship);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return relationships;
        }

        
    }
}
