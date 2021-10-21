using System;
using System.Collections.Generic;
using Product.Models.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Product.Models;
using System.Web.Configuration;

namespace Product.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            Database db = new Database();
            var user = db.users.Authenticate(Username, Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                Session["type"] = user.Type;
                if (user.Type == 1)
                    return RedirectToAction("List", "Admin");
                else
                    return RedirectToAction("Buy", "Product");
            }
            return View();
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
    }
}