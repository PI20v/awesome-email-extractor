using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace AwesomeEmailExtractor
{
    public class Logs
    {
        public class LogData {
            public User user;
            public string date;
            public Action action;
            public string message;
        }

        public enum Action
        {
            Execute,
            Login,
            Registration
        }

        public static void Log(User user, Action action, Dictionary<string, object> options)
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.logsDb;

            command.CommandText = "INSERT INTO logs (user_id, date, action, message) VALUES (@user_id, strftime('%Y-%m-%d %H:%M:%S', datetime('now')), @action, @message)";
            
            command.Parameters.AddWithValue("@user_id", user.ID);
            command.Parameters.AddWithValue("@action", action);
            command.Parameters.AddWithValue("@message", GetLogMessage(action, options));

            command.ExecuteNonQuery();
        }

        public static List<LogData> GetLogs(User user)
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.logsDb;

            command.CommandText = "SELECT date, action, message FROM logs WHERE user_id = @user_id ORDER BY date DESC";
            command.Parameters.AddWithValue("@user_id", user.ID);

            SqliteDataReader reader = command.ExecuteReader();

            List<LogData> logs = new List<LogData>();
            while (reader.Read())
            {
                logs.Add(new LogData()
                {
                    user = user,
                    date = reader.GetString(0),
                    action = (Action)reader.GetInt32(1),
                    message = reader.GetString(2)
                });
            }

            return logs;
        }

        public static List<LogData> GetLogs()
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.logsDb;
            command.CommandText = "ATTACH DATABASE @dbpath AS appDB";
            command.Parameters.AddWithValue("@dbpath", Globals.getAppDatabase());
            command.ExecuteNonQuery();
            
            command.CommandText = @"
                SELECT 
                    user_id,
                    CASE WHEN appDB.users.login is NULL THEN 'Deleted_' || user_id ELSE appDB.users.login END AS login
                    appDB.users.role,
                    date,
                    action,
                    message
                from logs LEFT JOIN appDB.users on logs.user_id = appDB.users.id ORDER BY date DESC";

            SqliteDataReader reader = command.ExecuteReader();

            List<LogData> logs = new List<LogData>();
            while (reader.Read())
            {
                logs.Add(new LogData()
                {
                    user = new User(reader.GetInt32(0), reader.GetString(1), (UserRoles)reader.GetInt32(2)),
                    date = reader.GetString(3),
                    action = (Action)reader.GetInt32(4),
                    message = reader.GetString(5)
                });
            }

            return logs;
        }

        public static string GetLogMessage(Action action, Dictionary<string, object> options)
        {
            if (action == Action.Execute)
            {
                string sourceText = (string)options["sourceText"];
                int count = (int)options["count"];
                List<string> uniqueEmails = options["uniqueEmails"] as List<string>;
                

                return $"Пользователь выполнил поиск email-ов c таким исходным текстом: [ {sourceText}. ]\n" +
                    $"Найдено {count} email-ов.\n" +
                    $"Список уникальных: {String.Join(", ", uniqueEmails)}.";
            }
            if (action == Action.Login)
            {
                return "Пользователь вошел в систему.";
            }
            if (action == Action.Registration)
            {
                return "Пользователь зарегистрировался в системе.";
            }

            return "";
        }
    }
}
