using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CommentsRepo : IRCRepository<Comment, int, string>
    {
        NewsPortalEntities db;

        public CommentsRepo(NewsPortalEntities db)
        {
            this.db = db;
        }

        public void Add(Comment e)
        {
            this.db.Comments.Add(e);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var com = db.Comments.FirstOrDefault(c => c.id == id);
            db.Comments.Remove(com);
            db.SaveChanges();
        }

        public void Edit(Comment e)
        {
            var com = db.Comments.FirstOrDefault(c => c.id == e.id);
            db.Entry(com).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Comment> Get()
        {
            return db.Comments.ToList();
        }

        public Comment Get(int id)
        {
            return db.Comments.FirstOrDefault(c => c.id == id);
        }

        public List<Comment> GetsByNewsID(int id)
        {
            return db.Comments.Where(c => c.NewsID == id).ToList();
        }

        public List<Comment> GetsByNewsID_Date(int id, string date)
        {
            return db.Comments.Where(c => c.NewsID.ToString().Contains(id.ToString()) && c.CDate.Contains(date)).ToList();
        }
    }
}
