using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CategoryRepo : IRepository<NewsCategory, int, string>
    {
        NewsPortalEntities db;

        public CategoryRepo(NewsPortalEntities db)
        {
            this.db = db;
        }
        public void Add(NewsCategory e)
        {
            this.db.NewsCategories.Add(e);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var cat = db.NewsCategories.FirstOrDefault(c => c.id == id);
            db.NewsCategories.Remove(cat);
            db.SaveChanges();
        }

        public void Edit(NewsCategory e)
        {
            var cat = db.NewsCategories.FirstOrDefault(c => c.id == e.id);
            db.Entry(cat).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<NewsCategory> Get()
        {
            return db.NewsCategories.ToList();
        }

        public NewsCategory Get(int id)
        {
            return db.NewsCategories.FirstOrDefault(c => c.id == id);
        }
    }
}
