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
            string query = String.Format("insert into Transitions values ('{0}','{1}','{2}')", t.Items, t.Price, t.Date);
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
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                    Date = reader.GetString(reader.GetOrdinal("Date"))

                };
                transitions.Add(t);
            }

            conn.Close();
            return transitions;
        }
    }
}
