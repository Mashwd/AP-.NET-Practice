using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Product.Models;
using Product.Models.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Web.Providers.Entities;
using System.Linq;
using System.Dynamic;
using System.Globalization;
using System.Web.Security;
using System.Web;
using System.Web.Configuration;

namespace Product.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            Database db = new Database();
            var products = db.Products.Get();
            return View(products);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            Database db = new Database();
            var user = db.users.Authenticate(Username, Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                return RedirectToAction("List");
            }
            return View();
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

        public ActionResult Buy()
        {
            Database db = new Database();
            var products = db.Products.Get();
            return View(products);
        }

        public ActionResult AddToChart(int id, int Quantity)
        {
            Database db = new Database();
            Product.Models.Entities.Product p = new Product.Models.Entities.Product();
            p = db.Products.Get(id);
            if (p.Quantity != 0)
            {
                db.Products.Update(p.Quantity - 1, id);
                p.Quantity = Quantity;

                string json = "";
                if (Session["chart"] == null)
                {
                    List<Models.Entities.Product> d = new List<Models.Entities.Product>();
                    d.Add(p);
                    json = new JavaScriptSerializer().Serialize(d);
                    Session["chart"] = (object)json;
                }
                else
                {
                    json = Session["chart"].ToString();
                    var d = new JavaScriptSerializer().Deserialize<List<Product.Models.Entities.Product>>(json);
                    bool flag = false;
                    for (int i = 0; i < d.Count; i++)
                    {
                        if (d[i].Id == p.Id)
                        {
                            d[i].Quantity = d[i].Quantity + p.Quantity;
                            d[i].Price = d[i].Quantity * p.Price;
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                        d.Add(p);
                    json = new JavaScriptSerializer().Serialize(d);
                    Session["chart"] = (object)json;
                }
            }
            return RedirectToAction("Buy");
        }

        public ActionResult Chart()
        {
            if (Session["chart"] != null)
            {
                string j = (string)Session["chart"];
                var d = new JavaScriptSerializer().Deserialize<List<Product.Models.Entities.Product>>(j);
                return View(d);
            }
            else
            {
                return View();
            }
        }

        public ActionResult DeleteFromChart(int id)
        {
            Database db = new Database();
            var p = db.Products.Get(id);
            db.Products.Update(p.Quantity + 1, id);
            string j = (string)Session["chart"];
            List<Product.Models.Entities.Product> d = new List<Models.Entities.Product>();
            d = new JavaScriptSerializer().Deserialize<List<Product.Models.Entities.Product>>(j);
            var itemToRemove = d.Single(r => r.Id == id);
            d.Remove(itemToRemove);
            j = new JavaScriptSerializer().Serialize(d);
            Session["chart"] = (object)j;
            return RedirectToAction("Chart");
        }

        public ActionResult CancelOrder()
        {
            if (Session["chart"] != null)
            {
                string j = (string)Session["chart"];
                List<Product.Models.Entities.Product> d = new List<Models.Entities.Product>();
                d = new JavaScriptSerializer().Deserialize<List<Product.Models.Entities.Product>>(j);

                Database db = new Database();
                foreach (var p in d)
                {
                    var product = db.Products.Get(p.Id);
                    db.Products.Update(p.Quantity + product.Quantity, p.Id);
                }
            }

            Session["chart"] = null;
            return RedirectToAction("Chart");
        }

        public ActionResult PlaceOrder()
        {
            if (Session["chart"] != null)
            {
                string j = (string)Session["chart"];
                List<Product.Models.Entities.Product> d = new List<Models.Entities.Product>();
                d = new JavaScriptSerializer().Deserialize<List<Product.Models.Entities.Product>>(j);

                Database db = new Database();

                DateTime localDate = DateTime.Now;
                string cultureName = "en-US";


                var culture = new CultureInfo(cultureName);

                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                string name = ticket.Name;

                Transition t = new Transition()
                {
                    Items = d.Count,
                    Price = d.Select(i => i.Price).Sum(),
                    Detials = Session["chart"].ToString(),
                    CustomerId = Convert.ToInt32(name),
                    Date = localDate.ToString(culture)
                };

                db.Transitions.Create(t);
                Session["chart"] = null;

            }
            return RedirectToAction("Buy");
        }

        public ActionResult TransitionList()
        {

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            string name = ticket.Name;

            Database db = new Database();
            var transitions = db.Transitions.GetMyOrder(Convert.ToInt32(name));
            return View(transitions);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            return RedirectToAction("Login");
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
    }
}