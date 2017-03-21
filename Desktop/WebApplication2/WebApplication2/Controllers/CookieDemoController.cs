using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class CookieDemoController : Controller
    {
        // GET: CookieDemo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            HttpCookie c = new HttpCookie(fc["txtKey"]);
            c.Value = fc["txtValue"];
            c.Path = Request.ApplicationPath;
            if (fc["chkIsPersistent"] == "Persistent")
                c.Expires = DateTime.MaxValue;
            if (fc["chkIsSecure"] == "Secure")
                c.Secure = true;
            Response.Cookies.Add(c);
            return View("Index");
        }

        public ActionResult RequestCookie(FormCollection fc)
        {
            string s;
            HttpCookie c = Request.Cookies[fc["txtKey"]];
            if (c == null)
                s = "Missing";
            else
                s = c.Value;
            ViewBag.Cookie = s;
            return View("Index");
        }

        public ActionResult GetAll(FormCollection fc)
        {
            string s = "";
            foreach (String key in Request.Cookies)
            {
                s += key + " " + Request.Cookies[key].Value + "<br>";
            }
            ViewBag.Cookie = s;
            return View("Index");
        }

        public ActionResult Remove(FormCollection fc)
        {
            HttpCookie c = new HttpCookie(fc["txtKey"]);
            c.Expires = DateTime.Now.AddDays(-1);
            c.Path = Request.ApplicationPath;
            Response.Cookies.Add(c);
            return View("Index");
        }


        public ActionResult CookieDic(FormCollection fc)
        {
            HttpCookie cookie = Request.Cookies[fc["txtKey"]];
            if (cookie == null)
                cookie = new HttpCookie(fc["txtKey"]);
            string subkey = fc["txtSubKey"];
            cookie.Values[subkey] = fc["txtValue"];
            if (fc["chkIsPersistent"] == "Persistent")
                cookie.Expires = DateTime.MaxValue;
            if (fc["chkIsSecure"] == "Secure")
                cookie.Secure = true;
            Response.Cookies.Add(cookie);
            return View("Index");
        }

        public ActionResult SessionsDemo()
        {
        string url = "http://" + Request.Url.Host + ":" + Request.Url.Port +
    Response.ApplyAppPathModifier(Request.ApplicationPath) + "/Home/Index";
            return View();
        }

    }
}