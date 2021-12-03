using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
   public class NewsModel
    {
        public int id { get; set; }
        public string Info { get; set; }
        public int PostedBy { get; set; }
        public string PostDate { get; set; }
        public string NewsCat { get; set; }
    }
}
