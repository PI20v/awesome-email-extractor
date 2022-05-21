using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Data.Sqlite;

namespace AwesomeEmailExtractor
{
    public class Authorization
    {
        public static User Login(string login, string password)
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "SELECT login, role_id FROM users WHERE login = @login AND password = @password";

            SqliteParameter loginParam = new SqliteParameter("@login", login);
            command.Parameters.Add(loginParam);

            SqliteParameter passwordParam = new SqliteParameter("@password", EncryptPassword(password));
            command.Parameters.Add(passwordParam);

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                return new User(reader.GetString(0), (UserRoles)reader.GetInt32(1));
            }

            throw new Exception("Пользователь не найден!");
        }

        public static User Register(string login, string password)
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "INSERT INTO users (login, password, role_id) VALUES (@login, @password, 0);";

            SqliteParameter loginParam = new SqliteParameter("@login", login);
            command.Parameters.Add(loginParam);

            SqliteParameter passwordParam = new SqliteParameter("@password", EncryptPassword(password));
            command.Parameters.Add(passwordParam);

            try
            {
                command.ExecuteNonQuery();
            } catch (SqliteException e)
            {
                if (e.SqliteErrorCode == 19) {
                    throw new Exception("Имя пользователя занятно!");
                }

                throw new Exception($"Ошибка: {e.Message}");
            };

            return new User(login, UserRoles.DEFAULT);
        } 

        public static string EncryptPassword(string password)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }
    }

    public enum UserRoles
    {
        DEFAULT,
        ADMIN
    }
    public class User
    {
        public string Login { get; set; }
        public UserRoles Role { get; }

        public User(string login, UserRoles role)
        {
            Login = login;
            Role = role;
        }
    }
}
