using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture_4.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Type { get; set; }
    }
}