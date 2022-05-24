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
            public int ID { get; set;  }
            public User User { get; set; }
            public string Date { get; set; }
            public Action Action { get; set; }
            public string Message { get; set; }

            public void Delete()
            {
                SqliteCommand command = new SqliteCommand();
                command.Connection = Globals.logsDb;
                command.CommandText = "DELETE FROM logs WHERE id = @id;";

                SqliteParameter idParam = new SqliteParameter("@id", ID);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
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

        public static List<LogData> GetLogsList(User user)
        {
            SqliteDataReader reader = GetLogsDataReader(user);

            List<LogData> logs = new List<LogData>();
            while (reader.Read())
            {
                logs.Add(new LogData()
                {
                    ID = Convert.ToInt32(reader["id"]),
                    User = user,
                    Date = Convert.ToString(reader["date"]),
                    Action = (Action)Convert.ToInt32(reader["action"]),
                    Message = Convert.ToString(reader["message"]),
                });
            }

            reader.Close();

            return logs;
        }

        private static SqliteDataReader GetLogsDataReader(User user)
        {
            if (Globals.currentUser.ID != user.ID && Globals.currentUser.Role != UserRoles.ADMIN)
            {
                throw new Exception("У вас нет прав на просмотр логов");
            }

            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.logsDb;
            command.CommandText = "SELECT id, date, action, message FROM logs WHERE user_id = @user_id ORDER BY date DESC";
            command.Parameters.AddWithValue("@user_id", user.ID);

            return command.ExecuteReader();
        }        

        public static List<LogData> GetLogsList()
        {
            if (Globals.currentUser.Role != UserRoles.ADMIN)
            {
                throw new Exception("У вас нет прав на просмотр логов");
            }

            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.logsDb;
            
            command.CommandText = @"
                SELECT
                    logs.id,
                    user_id,
                    CASE WHEN appDB.users.login is NULL THEN 'Deleted_' || user_id ELSE appDB.users.login END AS login,
                    CASE WHEN appDB.users.role_id is NULL THEN 0 ELSE appDB.users.role_id END AS role_id,
                    date,
                    action,
                    message
                from logs LEFT JOIN appDB.users on logs.user_id = appDB.users.id ORDER BY date DESC;";

            SqliteDataReader reader = command.ExecuteReader();

            List<LogData> logs = new List<LogData>();
            while (reader.Read())
            {
                logs.Add(new LogData()
                {
                    ID = Convert.ToInt32(reader["id"]),
                    User = new User(
                        Convert.ToInt32(reader["user_id"]), 
                        Convert.ToString(reader["login"]), 
                        (UserRoles)Convert.ToInt32(reader["role_id"])
                    ),
                    Date = Convert.ToString(reader["date"]),
                    Action = (Action)Convert.ToInt32(reader["action"]),
                    Message = Convert.ToString(reader["message"])
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

        public static void DeleteLog(LogData logData)
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.logsDb;

            command.CommandText = "DELETE FROM logsDB WHERE id = @id";

            command.Parameters.AddWithValue("@id", logData.ID);

            command.ExecuteNonQuery();
        }
    }
}
