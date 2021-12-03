using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CommentModel
    {
        public int id { get; set; }
        public int NewsID { get; set; }
        public int CommentedBy { get; set; }
        public string CDate { get; set; }
        public string CInfo { get; set; }
    }
}
