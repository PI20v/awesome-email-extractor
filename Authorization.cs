using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace AwesomeEmailExtractor
{
    public class Authorization
    {
        public static User Login(string login, string password)
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "SELECT id, login, role_id FROM users WHERE login = @login AND password = @password";

            SqliteParameter loginParam = new SqliteParameter("@login", login);
            command.Parameters.Add(loginParam);

            SqliteParameter passwordParam = new SqliteParameter("@password", EncryptPassword(password));
            command.Parameters.Add(passwordParam);

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                return new User(reader.GetInt32(0), reader.GetString(1), (UserRoles)reader.GetInt32(2));
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

            return Login(login, password);
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
        public int ID { get; }
        public string Login { get; }
        public UserRoles Role { get; }

        public User(int id, string login, UserRoles role)
        {
            ID = id;
            Login = login;
            Role = role;
        }

        public User(User user)
        {
            ID = user.ID;
            Login = user.Login;
            Role = user.Role;
        }

        public void Delete()
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "DELETE FROM users WHERE id = @id;";

            SqliteParameter idParam = new SqliteParameter("@id", ID);
            command.Parameters.Add(idParam);

            command.ExecuteNonQuery();
        }

        public void ChangePassword(string password)
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "UPDATE users SET password = @password WHERE id = @id;";

            SqliteParameter idParam = new SqliteParameter("@id", ID);
            command.Parameters.Add(idParam);

            SqliteParameter passwordParam = new SqliteParameter("@password", Authorization.EncryptPassword(password));
            command.Parameters.Add(passwordParam);
            
            command.ExecuteNonQuery();
        }

        new public string ToString()
        {
            return this.Login;
        }
    }

    public class AdminUtils
    {
        public User User { get; set; }

        public AdminUtils(User user)
        {
            User = user;
        }
        public void setRole(string login, UserRoles role)
        {
            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "UPDATE users SET role_id = @role WHERE login = @login";

            SqliteParameter roleParam = new SqliteParameter("@role", (int)role);
            command.Parameters.Add(roleParam);

            SqliteParameter loginParam = new SqliteParameter("@login", login);
            command.Parameters.Add(loginParam);

            command.ExecuteNonQuery();
        }
        public void deleteUser(string login)
        {
            if (User.Role != UserRoles.ADMIN)
            {
                throw new Exception("Недостаточно прав!");
            }

            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "DELETE FROM users WHERE login = @login";

            SqliteParameter loginParam = new SqliteParameter("@login", login);
            command.Parameters.Add(loginParam);

            command.ExecuteNonQuery();
        }
        public List<User> GetAllUsers()
        {
            if (User.Role != UserRoles.ADMIN)
            {
                throw new Exception("Недостаточно прав!");
            }

            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "SELECT id, login, role_id FROM users";

            SqliteDataReader reader = command.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                users.Add(new User(reader.GetInt32(0), reader.GetString(1), (UserRoles)reader.GetInt32(2)));
            }

            return users;
        }
    
        public void editUser(User user)
        {
            if (User.Role != UserRoles.ADMIN)
            {
                throw new Exception("Недостаточно прав!");
            }

            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "UPDATE users SET login = @login, role_id = @role_id WHERE id = @id";
            
            SqliteParameter idParam = new SqliteParameter("@id", user.ID);
            command.Parameters.Add(idParam);

            SqliteParameter loginParam = new SqliteParameter("@login", user.Login);
            command.Parameters.Add(loginParam);

            SqliteParameter roleParam = new SqliteParameter("@role_id", user.Role);
            command.Parameters.Add(roleParam);

            command.ExecuteNonQuery();
        }

        public void editUser(User user, string password)
        {
            editUser(user);
            user.ChangePassword(password);
        }
    }
}
