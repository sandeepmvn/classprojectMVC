using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    // [HandleError(ExceptionType = typeof(Exception), View = "Error1")]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            string cs = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return Content(cs);
        }
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }
        [OverrideExceptionFilters]
        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}