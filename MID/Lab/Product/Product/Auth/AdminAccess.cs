using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HttpContext = System.Web.HttpContext;

namespace Product.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAccess: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var context = HttpContext.Current;
            var flag = base.AuthorizeCore(httpContext);

            if (flag)
            {
                if (context.Session["type"] == null)
                    return false;
                else
                {
                    var s = context.Session["type"].ToString();
                    if (s == "1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
                return false;
        }
    }
}