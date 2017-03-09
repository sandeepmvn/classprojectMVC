using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ModelBindersDemoController : Controller
    {
        // GET: ModelBindersDemo
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection hobbies)
        {
            string str = hobbies["hobbies"];
            return View();
        }



        public ActionResult Employee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Employee(Employee employee,HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                string fileName = photo.FileName;
                photo.SaveAs(Server.MapPath("/Content/Images/" + fileName));
            }
            return View();
        }
    }
}