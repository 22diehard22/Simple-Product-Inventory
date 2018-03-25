using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

namespace ProductLibrary
{
    public class database
    {
        public SQLiteConnection myConnection;
        private string databaseFile = "./database.sqlite3", connectionString;

        public database()
        {
   
            connectionString = "Data Source=" + databaseFile;
            bool dbExist = createDatabaseFile(); // If DB exists, return true. 
            if (dbExist == false) // In the event the database file does not exist create the database tables. 
            {
                createProductTable();
            }

            // Test cases:
            // editProduct(1, "test2", "Update is successful2",10.1, false);  // Assumes you have an entry with ID 1
            // deleteProduct(1); // Assumes you have an entry with ID 1
            // insertProduct("lego block", "A 3x2 lego block", .02, true);
        }

        public string[] returnProduct(int id) // returns a single product
        {
            string[] rtnArray = new string[4];
            using (var connection = new SQLiteConnection(connectionString))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open(); // Create the following tables: 
                    command.CommandText = @"Select * FROM [products] where id =" + id;
                    command.ExecuteNonQuery();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rtnArray[0] = reader["name"].ToString();
                            rtnArray[1] = reader["description"].ToString(); 
                            rtnArray[2] = reader["price"].ToString();
                            rtnArray[3] = reader["active"].ToString();
                        }
                        return (rtnArray);
                    }
                }
            }
        }


        public DataTable returnProducts() // returns ALL
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("description", typeof(string));
            table.Columns.Add("price", typeof(double));
            table.Columns.Add("active", typeof(bool));

            using (var connection = new SQLiteConnection(connectionString))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open(); // Create the following tables: 
                    command.CommandText = @"Select * FROM [products]";
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            table.Rows.Add(reader["id"], reader["Name"].ToString(), reader["description"].ToString(), reader["price"], reader["active"]);
                        }
                        return (table);
                    }
                }
            }
        }
        public void editProduct(int id, string name, string description, double price, bool active)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = @"UPDATE [products] set name='" + name + "',Description='" + description + "',price='" + price + "',active='" + active + "' where id="+id ;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void deleteProduct(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = @"delete from [products] where id = " + id; ;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void insertProduct(string name, string description, double price, bool active)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    command.CommandText = @"INSERT INTO [products] (Name,description,price,active) VALUES ('" + name + "','" + description + "','" + price + "','" + active + "')";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private void createProductTable()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open(); // Create the following tables: 
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS[products](
                       [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                       [name] NVARCHAR(2048)  NULL,
                       [description] NVCHAR(2048) NULL,
                       [price] DOUBLE NULL,
                       [active] BOOLEAN NULL)";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private bool createDatabaseFile()
        {
            if (!File.Exists(databaseFile))
            {
                SQLiteConnection.CreateFile(databaseFile);
                return (false);
            }
            else
            {
                return (true);
            }
        }
    }
}