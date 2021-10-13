using Lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var db = new UMSEntities();
            var categories = db.Categories.ToList();
            return View(categories);
        }

        public ActionResult Details(int id)
        {
            var db = new UMSEntities();
            var data = (from d in db.Categories
                        where d.Id == id
                        select d).FirstOrDefault();
            return View(data);
        }
    }
}