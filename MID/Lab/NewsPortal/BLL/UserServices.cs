using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BEL;
using BLL;
using DAL;

namespace BLL
{
    public class UserServices
    {
        public static List<NewsModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetail, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().Get());
            return data;
        }

        public static List<CommentModel> GetAllComments(int newsId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetail, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CommentModel>>(DataAccessFactory.CommentDataAccess().GetsByNewsID(newsId));
            return data;
        }

        public static List<ReactionModel> GetAllRects(int newsId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetail, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ReactionModel>>(DataAccessFactory.ReactionDataAccess().GetsByNewsID(newsId));
            return data;
        }
    }
}
