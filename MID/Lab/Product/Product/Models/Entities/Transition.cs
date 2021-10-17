using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Models.Entities
{
    public class Transition
    {
        public int Id { get; set; }
        public int Items { get; set; }
        public double Price { get; set; }
        public string Detials { get; set; }
        public int CustomerId { get; set; }
        public string Date { get; set; }
    }
}