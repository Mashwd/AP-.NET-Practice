using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please put product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please put product quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please put product price")]
        public double Price { get; set; }
    }
}