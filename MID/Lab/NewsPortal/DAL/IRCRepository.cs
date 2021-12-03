using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRCRepository<T, ID, SID> : IRepository<T, ID, SID>
    {
        List<T> GetsByNewsID(ID id);
        List<T> GetsByNewsID_Date(ID id, SID date);
    }
}
