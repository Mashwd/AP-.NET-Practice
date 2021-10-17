using Lecture_4.Models.Tables;
using Product.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Product.Models
{
    public class Database
    {
        SqlConnection conn;
        public Products Products { get; set; }
        public Transitions Transitions { get; set; }
        public Users users { get; set; }
        public Database()
        {
            string connString = @"Server=LAPTOP-MPKJ7QD8\SQLEXPRESS; Database=UMS; Integrated Security=true";
            conn = new SqlConnection(connString);
            Products = new Products(conn);
            Transitions = new Transitions(conn);
            users = new Users(conn);
        }
    }
}