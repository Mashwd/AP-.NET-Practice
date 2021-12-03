using AutoMapper;
using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminServices
    {
        public static void InsertNews(NewsModel n)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsModel, NewsDetail>());
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsDetail>(n);
            DataAccessFactory.NewsDataAccess().Add(data);
        }

        public static void DeleteNews(int id)
        {
            DataAccessFactory.NewsDataAccess().Delete(id);
        }

        public static void UpdateNews(NewsModel n)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsModel, NewsDetail>());
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsDetail>(n);
            DataAccessFactory.NewsDataAccess().Edit(data);
        }

        public static NewsModel GetNews(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetail, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsModel>(DataAccessFactory.NewsDataAccess().Get(id));
            return data;   
        }

        public static List<NewsModel> GetAllNews()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetail, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().Get());
            return data;
        }

        public static void InsertCategory(NewsCategoryModel nc)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsCategoryModel, NewsCategory>());
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsCategory>(nc);
            DataAccessFactory.CategoryDataAccess().Add(data);
        }

        public static void DeleteCategory(int id)
        {
            DataAccessFactory.CategoryDataAccess().Delete(id);
        }

        public static void UpdateCategory(NewsCategoryModel nc)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsCategoryModel, NewsCategory>());
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsCategory>(nc);
            DataAccessFactory.CategoryDataAccess().Edit(data);
        }

        public static NewsCategoryModel GetCategory(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsCategory, NewsCategoryModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<NewsCategoryModel>(DataAccessFactory.CategoryDataAccess().Get(id));
            return data;
        }

        public static List<NewsCategoryModel> GetAllCategory()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsCategory, NewsCategoryModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsCategoryModel>>(DataAccessFactory.CategoryDataAccess().Get());
            return data;
        }

        public static List<NewsModel> GetNewsByCategory(string category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetail, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().GetNewsByCategory(category));
            return data;
        }

        public static List<NewsModel> GetNewsByDate(string date)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetail, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().GetNewsByDate(date));
            return data;
        }

        public static List<NewsModel> GetNewsByCategory_Date(string category, string date)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetail, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().GetNewsByCategory_Date(category, date));
            return data;
        }

        public static BindNewsWithRC GetNewsWithRC(int id)
        {
            var data = new BindNewsWithRC();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetail, NewsModel>());
            var mapper = new Mapper(config);
            data.news = mapper.Map<NewsModel>(DataAccessFactory.NewsDataAccess().Get(id));

            config = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentModel>());
            mapper = new Mapper(config);
            data.Comments = mapper.Map<List<CommentModel>>(DataAccessFactory.CommentDataAccess().GetsByNewsID(id));

            config = new MapperConfiguration(cfg => cfg.CreateMap<Reaction, ReactionModel>());
            mapper = new Mapper(config);
            data.Reactions = mapper.Map<List<ReactionModel>>(DataAccessFactory.ReactionDataAccess().GetsByNewsID(id));

            return data;
        }
    }
}
