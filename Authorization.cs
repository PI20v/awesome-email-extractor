﻿using System;
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
            command.CommandText = "SELECT * FROM users WHERE login = @login AND password = @password";

            SqliteParameter loginParam = new SqliteParameter("@login", login);
            command.Parameters.Add(loginParam);

            SqliteParameter passwordParam = new SqliteParameter("@password", EncryptPassword(password));
            command.Parameters.Add(passwordParam);

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                return new User(reader.GetInt32(0), reader.GetString(1), (UserRoles)reader.GetInt32(1));
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
            if (User.Role != UserRoles.ADMIN)
            {
                throw new Exception("Недостаточно прав!");
            }

            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "UPDATE users SET role_id = @role WHERE login = @login";

            SqliteParameter roleParam = new SqliteParameter("@role", (int)role);
            command.Parameters.Add(roleParam);

            SqliteParameter loginParam = new SqliteParameter("@login", login);
            command.Parameters.Add(loginParam);

            command.ExecuteNonQuery();
        }

        public List<User> getAllUsers()
        {
            if (User.Role != UserRoles.ADMIN)
            {
                throw new Exception("Недостаточно прав!");
            }

            SqliteCommand command = new SqliteCommand();
            command.Connection = Globals.db;
            command.CommandText = "SELECT * FROM users";

            SqliteDataReader reader = command.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                users.Add(new User(reader.GetInt32(0), reader.GetString(1), (UserRoles)reader.GetInt32(2)));
            }

            return users;
        }
    }
}
