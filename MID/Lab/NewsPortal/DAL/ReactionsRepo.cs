using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class ReactionsRepo : IRCRepository<Reaction, int, string>
    {
        NewsPortalEntities db;

        public ReactionsRepo(NewsPortalEntities db)
        {
            this.db = db;
        }

        public void Add(Reaction e)
        {
            this.db.Reactions.Add(e);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var react = db.Reactions.FirstOrDefault(c => c.id == id);
            db.Reactions.Remove(react);
            db.SaveChanges();
        }

        public void Edit(Reaction e)
        {
            var react = db.Reactions.FirstOrDefault(c => c.id == e.id);
            db.Entry(react).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Reaction> Get()
        {
            return db.Reactions.ToList();
        }

        public Reaction Get(int id)
        {
            return db.Reactions.FirstOrDefault(c => c.id == id);
        }

        public List<Reaction> GetsByNewsID(int id)
        {
            return db.Reactions.Where(c => c.NewsID == id).ToList();
        }

        public List<Reaction> GetsByNewsID_Date(int id, string date)
        {
            return db.Reactions.Where(c => c.NewsID.ToString().Contains(id.ToString()) && c.RDate.Contains(date)).ToList();
        }
    }
}
