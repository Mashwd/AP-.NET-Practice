using BEL;
using BLL;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsPortal.Controllers
{
    [EnableCors()]
    public class UserController : ApiController
    {
        [Route("NewsPortalAPI/User/News/All")]
        [HttpGet]
        public List<NewsModel> GetAll()
        {
            return UserServices.GetAll();
        }
        /*[Route("api/Product/Names")]
        [HttpGet]
        public List<string> Names()
        {
            return ProductService.GetNames();
        }*/
    }
}
