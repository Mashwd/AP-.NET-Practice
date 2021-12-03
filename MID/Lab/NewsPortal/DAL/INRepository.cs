using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface INRepository<T, ID, SID> : IRepository<T, ID, SID>
    {
        List<T> GetNewsByCategory(SID category);
        List<T> GetNewsByCategory_Date(SID category, SID date);
        List<T> GetNewsByDate(SID date);
    }
}
