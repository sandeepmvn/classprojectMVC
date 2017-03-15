using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            ViewBag.ReturnUrl = Request.QueryString["ReturnUrl"];
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserProfileModel userProfile)
        {
            if (userProfile.UserName == userProfile.Password)
            {
                HttpCookie cookie = new HttpCookie("AuthCookie");
                cookie.Value = userProfile.UserName;
                if (userProfile.RememberMe)
                    cookie.Expires = DateTime.MaxValue;
                cookie.Path = Request.ApplicationPath;
                Response.Cookies.Add(cookie);
                string returl = Request.QueryString["ReturnUrl"];
                if (string.IsNullOrEmpty(returl))
                    return Redirect("/");
                else
                    return Redirect(returl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid password or UserName");
            }
            return View(userProfile);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies["Authcookie"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            cookie.Path = Request.ApplicationPath;
            Response.Cookies.Add(cookie);
            return View("Login");
        }

    }
}