using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class UserRepo : IRepository<User, int, string>
    {
        NewsPortalEntities db;

        public UserRepo(NewsPortalEntities db)
        {
            this.db = db;
        }

        public void Add(User e)
        {
            this.db.Users.Add(e);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = db.Users.FirstOrDefault(c => c.id == id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void Edit(User e)
        {
            var user = db.Users.FirstOrDefault(c => c.id == e.id);
            db.Entry(user).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(c => c.id == id);
        }
    }
}
