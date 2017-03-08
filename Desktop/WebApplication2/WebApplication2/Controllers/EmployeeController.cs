using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return new HttpUnauthorizedResult();
        }

       public ActionResult Hello()
       {
            return Content("<Employee><FirstName>Sandeep</FirstName><LastName>M</LastName></Employee>","text/xml");
       }
       public ActionResult Result()
       {
            return JavaScript("alert('Hai')");
       }

    }
}