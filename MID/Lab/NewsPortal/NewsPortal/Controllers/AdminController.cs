using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NewsPortal.Controllers
{
    public class AdminController : ApiController
    {
        [Route("NewsPortalAPI/Admin/News/Add/")]
        [HttpPost]
        public void Add(NewsModel n)
        {
            AdminServices.InsertNews(n);
        }

        [Route("NewsPortalAPI/Admin/News/Edit/")]
        [HttpPost]
        public void Edit(NewsModel n)
        {
            AdminServices.UpdateNews(n);
        }

        [Route("NewsPortalAPI/Admin/News/Delete/{id}")]
        [HttpPost]
        public void Delete(int id)
        {
            AdminServices.DeleteNews(id);
        }

        [Route("NewsPortalAPI/Admin/News/{id}")]
        [HttpGet]
        public NewsModel News(int id)
        {
            return AdminServices.GetNews(id);
        }

        [Route("NewsPortalAPI/Admin/News/Comment_Reactions/{id}")]
        [HttpGet]
        public BindNewsWithRC NewsWithRC(int id)
        {
            return AdminServices.GetNewsWithRC(id);
        }

        [Route("NewsPortalAPI/Admin/News/Category/Add/")]
        [HttpPost]
        public void AddCategory(NewsCategoryModel n)
        {
            AdminServices.InsertCategory(n);
        }

        [Route("NewsPortalAPI/Admin/News/Category/Edit/")]
        [HttpPost]
        public void EditCategory(NewsCategoryModel n)
        {
            AdminServices.UpdateCategory(n);
        }

        [Route("NewsPortalAPI/Admin/News/Category/Delete/{id}")]
        [HttpPost]
        public void DeleteCategory(int id)
        {
            AdminServices.DeleteCategory(id);
        }

        [Route("NewsPortalAPI/Admin/News/Category/{id}")]
        [HttpGet]
        public NewsCategoryModel NewsCategory(int id)
        {
            return AdminServices.GetCategory(id);
        }

        [Route("NewsPortalAPI/Admin/News/ByCategory/{cat}")]
        [HttpGet]
        public void AddCategory(string cat)
        {
            AdminServices.GetNewsByCategory(cat);
        }

        [Route("NewsPortalAPI/Admin/News/ByCategory/{cat}/{date}")]
        [HttpGet]
        public void AddCategory(string cat, string date)
        {
            AdminServices.GetNewsByCategory_Date(cat, date);
        }
    }
}
