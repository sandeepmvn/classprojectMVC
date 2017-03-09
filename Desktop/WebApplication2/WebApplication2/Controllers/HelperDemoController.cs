using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Course
    {
        public int CoursesId { get; set; }
        public string CourseName { get; set; }
    }

    public class HelperDemoController : Controller
    {
        // GET: HelperDemo
        public ActionResult Index()
        {
            List<Course> lst = new List<Course>()
            {
            new Course() {CoursesId=1,CourseName="C#" },
            new Course() {CoursesId=2,CourseName="Asp.net" },
            new Course() {CoursesId=3,CourseName="C" }
            };
            ViewBag.Courses = new SelectList(lst, "CoursesId", "CourseName");
            //ViewData["Id"] = 1;
            //ViewData["Name"] = "E1";
            //ViewData["Salary"] = 10000;
            //ViewData["IsActive"] = true;
            //ViewData["DeptId"] = 2;
            //ViewData["DateOfJoin"] = DateTime.Now;
            //ViewData["EmailAddress"] = "test@test.com";

            Student std = new Student()
            {
                Id = 1,
                Name = "E1",
                Salary = 10000,
                IsActive = true,
                DateOfJoin = DateTime.Now,
                EmailAddress="sandeep.mvn@deccansoft.com"
            };

            return View(std);
        }

        [HttpPost]
        public ActionResult Index(Student std)
        {
            List<Course> lst = new List<Course>()
            {
            new Course() {CoursesId=1,CourseName="C#" },
            new Course() {CoursesId=2,CourseName="Asp.net" },
            new Course() {CoursesId=3,CourseName="C" }
            };
            ViewBag.Courses = new SelectList(lst, "CoursesId", "CourseName");
            ModelState.Clear();
            std.Name = "San";
            return View(std);
        }

        public ActionResult EnumExample()
        {
            return View();
        }
    }
}