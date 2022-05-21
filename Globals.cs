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
        public static SqliteConnection logsDb { get; set; }

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

        public static string getDefaultPathAppLogs()
        {
            return Path.Combine(
                getAppDirectory(),
                "logs.db"
            );
        }

        public static string getPathAppLogs()
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = db;
            command.CommandText = "SELECT logs_db_path FROM app_settings LIMIT 1";

            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["logs_db_path"].ToString();
            }

            return getDefaultPathAppLogs();
        }
        
        public static void CreateLogsTable()
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = logsDb;

            command.CommandText = "CREATE TABLE IF NOT EXISTS logs_actions (id INTEGER PRIMARY KEY, name TEXT NOT NULL)";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT OR IGNORE INTO logs_actions (id, name) VALUES (0, 'Выполнение');";
            command.ExecuteNonQuery();

            command.CommandText = "CREATE TABLE IF NOT EXISTS logs (id INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER NOT NULL, date TEXT NOT NULL, action INTEGER NOT NULL, message TEXT NOT NULL, FOREIGN KEY(action) REFERENCES logs_actions(id));";
            command.ExecuteNonQuery();

        }

        public static void CreateTables()
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = db;
            
            // Создать таблицу для хранения ролей
            command.CommandText = "CREATE TABLE IF NOT EXISTS roles (id INTEGER PRIMARY KEY, name TEXT NOT NULL);";
            command.ExecuteNonQuery();

            // Добавить роли
            command.CommandText = "INSERT OR IGNORE INTO roles (id, name) VALUES (0, 'Обычный'), (1, 'Администратор');";
            command.ExecuteNonQuery();

            // Создать таблицу для хранения настроек (знаю, так плохо, но сойдет)
            command.CommandText = "CREATE TABLE IF NOT EXISTS app_settings (logs_db_path TEXT);";
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

            command.CommandText = "SELECT COUNT(*) FROM app_settings";

            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
            {
                command.CommandText = "INSERT INTO app_settings (logs_db_path) VALUES (@logs_db_path);";

                SqliteParameter logsDbPathParam = new SqliteParameter("@logs_db_path", getDefaultPathAppLogs());
                command.Parameters.Add(logsDbPathParam);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
    }
}
