using Lecture_4.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture_4.Models.Tables
{
    public class Users
    {
        SqlConnection conn;
        public Users(SqlConnection conn)
        {
            this.conn = conn;
        }

        public List<User> Get()
        {
            List<User> users = new List<User>();
            User user = null;
            conn.Open();
            string query = "Select * From Users";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new User();
                user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                user.Username = reader.GetString(reader.GetOrdinal("Username"));
                user.Password = reader.GetString(reader.GetOrdinal("Password"));
                user.Type = reader.GetInt32(reader.GetOrdinal("Type"));
                users.Add(user);
            }
            return users;
        }

        public User Authenticate(string username, string password)
        {
            User user = null;
            conn.Open();
            string query = String.Format("Select * From Users Where Username = '{0}' and Password = '{1}'", username, password);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new User();
                user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                user.Username = reader.GetString(reader.GetOrdinal("Username"));
                user.Password = reader.GetString(reader.GetOrdinal("Password"));
                user.Type = reader.GetInt32(reader.GetOrdinal("Type"));
            }
            return user;
        }
    }
}