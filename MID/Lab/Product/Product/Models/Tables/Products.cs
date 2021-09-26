using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Product.Models.Entities;

namespace Product.Models.Tables
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Create(Product.Models.Entities.Product p)
        {

            conn.Open();
            string query = String.Format("insert into Products values ('{0}','{1}','{2}')", p.Name, p.Quantity, p.Price);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Product.Models.Entities.Product> Get()
        {
            conn.Open();
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product.Models.Entities.Product> students = new List<Product.Models.Entities.Product>();
            while (reader.Read())
            {
                Product.Models.Entities.Product s = new Product.Models.Entities.Product()
                {

                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price"))

                };
                students.Add(s);
            }

            conn.Close();
            return students;
        }
        public Product.Models.Entities.Product Get(int id)
        {
            conn.Open();
            string query = String.Format("Select * from Products where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Product.Models.Entities.Product s = null;
            while (reader.Read())
            {
                s = new Product.Models.Entities.Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price"))
                };
            }
            conn.Close();
            return s;
        }

        public bool Update(Product.Models.Entities.Product p, int id)
        {
            conn.Open();
            string query = "UPDATE Products Set Name = '" + p.Name + "', Quantity = " + p.Quantity + ", Price = " + p.Price + " WHERE Id = " + id + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();

            return res>1? true:false;
        }

        public bool Delete(int id)
        {
            conn.Open();
            string query = "DELETE from Products WHERE Id = " + id + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();

            return res > 1 ? true : false;
        }
    }
}