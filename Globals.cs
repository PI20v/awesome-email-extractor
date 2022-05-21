using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.Sqlite;


namespace AwesomeEmailExtractor
{
    internal class Globals
    {
        // Getter and setter for SQLite database connection
        public static SqliteConnection db { get; set; }

        public static string getAppDirectory()
        {
            return Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData
                ),
                 "AwesomeEmailExtractor"
            );
        }

        public static string getAppDatabase()
        {
            return Path.Combine(
                getAppDirectory(),
                "database.db"
            );
        }

            

        public static void CreateTables()
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = db;
            
            // Создать таблицу для хранения ролей
            command.CommandText = "CREATE TABLE IF NOT EXISTS roles (id INTEGER PRIMARY KEY, name TEXT NOT NULL);";
            command.ExecuteNonQuery();

            // Добавить роли
            command.CommandText = "INSERT OR IGNORE INTO roles (id, name) VALUES (0, 'DEFAULT'), (1, 'ADMIN');";
            command.ExecuteNonQuery();

            // Создать таблицу для хранения пользователей
            command.CommandText = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY AUTOINCREMENT, login TEXT NOT NULL UNIQUE, password TEXT NOT NULL, role_id INTEGER NOT NULL, FOREIGN KEY(role_id) REFERENCES roles(id));";
            command.ExecuteNonQuery();

            // Если таблица пуста - добавить пользователя по умолчанию
            command.CommandText = "SELECT COUNT(*) FROM users";

            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
            {
                command.CommandText = "INSERT INTO users (login, password, role_id) VALUES ('admin', @password, 1);";

                SqliteParameter passwordParam = new SqliteParameter("@password", Authorization.EncryptPassword("admin"));
                command.Parameters.Add(passwordParam);                
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
    }
}
