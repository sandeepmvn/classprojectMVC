using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DataAnnotationDemoController : Controller
    {
        // GET: DataAnnotationDemo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {

            }
            ModelState.AddModelError("", "");
            return View(userProfile);
        }
    }
}