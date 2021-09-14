using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVApplication.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Bio()
        {
            return View();
        }
        public ActionResult Education()
        {
            return View();
        }
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult Reference()
        {
            return View();
        }
    }
}