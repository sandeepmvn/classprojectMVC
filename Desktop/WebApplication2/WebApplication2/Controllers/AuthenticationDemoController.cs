using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class AuthenticationDemoController : Controller
    {
        // GET: AuthenticationDemo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string t1)
        {
            string t2 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(t1, "SHA1");
            return Content(t2);
        }
    }
}