using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BindNewsWithRC
    {
        public NewsModel news { get; set; }
        public List<CommentModel> Comments { set; get; }
        public List<ReactionModel> Reactions { get; set; }
    }
}
