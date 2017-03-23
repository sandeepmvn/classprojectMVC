using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        
            if (FormsAuthentication.Authenticate(userProfile.UserName, userProfile.Password))
            {

                //FormsAuthentication.SetAuthCookie(userProfile.UserName, userProfile.RememberMe);
                //HttpCookie cookie = new HttpCookie("AuthCookie");
                //cookie.Value = userProfile.UserName;
                //if (userProfile.RememberMe)
                //    cookie.Expires = DateTime.MaxValue;
                //cookie.Path = Request.ApplicationPath;
                //Response.Cookies.Add(cookie);
                //string returl = Request.QueryString["ReturnUrl"];
                //if (string.IsNullOrEmpty(returl))
                //    return Redirect(FormsAuthentication.DefaultUrl);
                //else
                //    return Redirect(returl);
                FormsAuthentication.RedirectFromLoginPage(userProfile.UserName, userProfile.RememberMe);
            }
            else
            {
                ModelState.AddModelError("", "Invalid password or UserName");
            }
            return View(userProfile);
        }

        [Authorize(Roles="View")]
        public ActionResult About()
        {
            ViewBag.Roles = "View";
            return View();
        }

        [Authorize(Roles ="Create")]
        public ActionResult Create()
        {
            ViewBag.Roles = "create";
            return View("About");
        }

        [Authorize(Roles = "Edit")]
        public ActionResult Edit()
        {
            ViewBag.Roles = "edit";
            return View("About");
        }
        public ActionResult Logout()
        {
            //HttpCookie cookie = Request.Cookies["Authcookie"];
            //cookie.Expires = DateTime.Now.AddDays(-1);
            //cookie.Path = Request.ApplicationPath;
            //Response.Cookies.Add(cookie);
            FormsAuthentication.SignOut();
            return View("Login");
        }

    }
}