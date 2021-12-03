using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class NewsRepo : INRepository<NewsDetail, int, string>
    {
        NewsPortalEntities db;

        public NewsRepo(NewsPortalEntities db)
        {
            this.db = db;
        }

        public void Add(NewsDetail e)
        {
            this.db.NewsDetails.Add(e);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var news = db.NewsDetails.FirstOrDefault(c => c.id == id);
            db.NewsDetails.Remove(news);
            db.SaveChanges();
        }

        public void Edit(NewsDetail e)
        {
            var news = db.NewsDetails.FirstOrDefault(c => c.id == e.id);
            db.Entry(news).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<NewsDetail> Get()
        {
            var data = db.NewsDetails.ToList();
            if (data.Count() > 0)
                return data;
            else
                return null;
        }

        public NewsDetail Get(int id)
        {
            return db.NewsDetails.FirstOrDefault(c => c.id == id);
        }

        public List<NewsDetail> GetNewsByCategory(string category)
        {
            return db.NewsDetails.Where(c => c.NewsCat.ToLower().Contains(category.ToLower())).ToList();
        }

        public List<NewsDetail> GetNewsByCategory_Date(string category, string date)
        {
            return db.NewsDetails.Where(c => c.NewsCat.Contains(category) && c.PostDate.Contains(date)).ToList();
        }

        public List<NewsDetail> GetNewsByDate(string date)
        {
            return db.NewsDetails.Where(c => c.PostDate.Contains(date)).ToList();
        }
    }
}
