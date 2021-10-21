using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BuyerAccess: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var context = HttpContext.Current;
            var flag = base.AuthorizeCore(httpContext);

            if (flag)
            {
                var s = context.Session["type"].ToString();
                if (s == "2")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}