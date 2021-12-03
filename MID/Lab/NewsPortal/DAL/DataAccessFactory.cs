using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static NewsPortalEntities db;

        static DataAccessFactory()
        {
            db = new NewsPortalEntities();
        }

        public static INRepository<NewsDetail, int, string> NewsDataAccess()
        {
            return new NewsRepo(db);
        }

        public static IRepository<User, int, String> UserDataAccess()
        {
            return new UserRepo(db);
        }

        public static IRepository<NewsCategory, int, String> CategoryDataAccess()
        {
            return new CategoryRepo(db);
        }

        public static IRCRepository<Comment, int, String> CommentDataAccess()
        {
            return new CommentsRepo(db);
        }

        public static IRCRepository<Reaction, int, String> ReactionDataAccess()
        {
            return new ReactionsRepo(db);
        }

    }
}
