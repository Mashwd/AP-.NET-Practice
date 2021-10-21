using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Product.Models.Tables
{
    public class Transitions
    {
        SqlConnection conn;
        public Transitions(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Create(Product.Models.Entities.Transition t)
        {

            conn.Open();
            string query = String.Format("insert into Transitions values ('{0}','{1}','{2}', '{3}', '{4}', '{5}')", t.Items, t.Detials, t.Price, t.CustomerId, t.Status, t.Date);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Product.Models.Entities.Transition> Get()
        {
            conn.Open();
            string query = "select * from Transitions";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product.Models.Entities.Transition> transitions = new List<Product.Models.Entities.Transition>();
            while (reader.Read())
            {
                Product.Models.Entities.Transition t = new Product.Models.Entities.Transition()
                {

                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Items = reader.GetInt32(reader.GetOrdinal("Items")),
                    CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                    Detials = reader.GetString(reader.GetOrdinal("Detials")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Date = reader.GetString(reader.GetOrdinal("Date"))

                };
                transitions.Add(t);
            }

            conn.Close();
            return transitions;
        }

        public List<Product.Models.Entities.Transition> Get(string status)
        {
            conn.Open();
            string query = String.Format("select * from Transitions where Status='{0}'", status);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product.Models.Entities.Transition> transitions = new List<Product.Models.Entities.Transition>();
            while (reader.Read())
            {
                Product.Models.Entities.Transition t = new Product.Models.Entities.Transition()
                {

                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Items = reader.GetInt32(reader.GetOrdinal("Items")),
                    CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                    Detials = reader.GetString(reader.GetOrdinal("Detials")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Date = reader.GetString(reader.GetOrdinal("Date"))

                };
                transitions.Add(t);
            }

            conn.Close();
            return transitions;
        }


        public List<Product.Models.Entities.Transition> GetMyOrder(int id)
        {
            conn.Open();
            string query = String.Format("select * from Transitions where CustomerId= '{0}'", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product.Models.Entities.Transition> transitions = new List<Product.Models.Entities.Transition>();
            while (reader.Read())
            {
                Product.Models.Entities.Transition t = new Product.Models.Entities.Transition()
                {

                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Items = reader.GetInt32(reader.GetOrdinal("Items")),
                    CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                    Detials = reader.GetString(reader.GetOrdinal("Detials")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Date = reader.GetString(reader.GetOrdinal("Date"))

                };
                transitions.Add(t);
            }

            conn.Close();
            return transitions;
        }


        public Product.Models.Entities.Transition Get(int id)
        {
            conn.Open();
            string query = String.Format("select * from Transitions where Id= '{0}'", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Product.Models.Entities.Transition t = null;
            while (reader.Read())
            {
                t = new Product.Models.Entities.Transition()
                {

                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Items = reader.GetInt32(reader.GetOrdinal("Items")),
                    CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                    Detials = reader.GetString(reader.GetOrdinal("Detials")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Date = reader.GetString(reader.GetOrdinal("Date"))

                };
            }

            conn.Close();
            return t;
        }

        public void UpdateStatus(int id, string status)
        {
            conn.Open();
            string query = String.Format("Update Transitions Set Status = '{0}' Where Id = '{1}'; ", status, id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
