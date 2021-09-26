using System.Web.Mvc;
using Product.Models;
using Product.Models.Entities;

namespace Product.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
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
    }
}