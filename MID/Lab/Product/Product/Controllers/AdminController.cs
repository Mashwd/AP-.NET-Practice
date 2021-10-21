using Product.Auth;
using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Product.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult List()
        {
            Database db = new Database();
            var products = db.Products.Get();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Product.Models.Entities.Product p = new Product.Models.Entities.Product();
            return View(p);
        }

        [HttpPost]
        public ActionResult Create(Product.Models.Entities.Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Create(p);
                return RedirectToAction("List");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Database db = new Database();
            var p = db.Products.Get(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Update(Product.Models.Entities.Product p, int id)
        {
            Database db = new Database();
            if (ModelState.IsValid)
            {
                db.Products.Update(p, id);
                return RedirectToAction("List");
            }
            return View(p);
        }


        public ActionResult Delete(int id)
        {
            Database db = new Database();
            db.Products.Delete(id);
            return RedirectToAction("List");
        }

        public ActionResult OrderList()
        {
            Database db = new Database();
            var transitions = db.Transitions.Get("Pending");
            return View(transitions);
        }

        public ActionResult InProcessingOrder()
        {
            Database db = new Database();
            var transitions = db.Transitions.Get("Processing");
            return View(transitions);
        }

        public ActionResult CanceledOrder()
        {
            Database db = new Database();
            var transitions = db.Transitions.Get("Canceled");
            return View(transitions);
        }

        [HttpGet]
        public ActionResult OrderDetials(int id)
        {
            Database db = new Database();
            var p = db.Transitions.Get(id);
            string j = p.Detials;
            List<Product.Models.Entities.Product> d = new List<Models.Entities.Product>();
            d = new JavaScriptSerializer().Deserialize<List<Product.Models.Entities.Product>>(j);

            return View(d);
        }

        public ActionResult Process(int id)
        {
            Database db = new Database();
            db.Transitions.UpdateStatus(id, "Processing");
            return RedirectToAction("OrderList", "Admin");
        }

        public ActionResult Cancel(int id)
        {
            Database db = new Database();
            db.Transitions.UpdateStatus(id, "Canceled");
            return RedirectToAction("OrderList", "Admin");
        }
    }
}