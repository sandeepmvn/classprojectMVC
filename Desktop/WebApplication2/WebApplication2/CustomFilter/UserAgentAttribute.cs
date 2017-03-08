using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2
{
    public class UserAgentAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string bowserName = filterContext.HttpContext.Request.UserAgent;
            string userAddress = filterContext.HttpContext.Request.UserHostAddress;
            if (bowserName.Contains("Trident"))
            {
                HttpNotFoundResult httpnotfound = new HttpNotFoundResult();
                filterContext.Result = httpnotfound;
            }
            else if(bowserName.Contains("Chrome"))
            {
                ViewResult view = new ViewResult();
                view.ViewName = "about";
                filterContext.Result = view;
            }
            else if (bowserName.Contains("Firefox"))
            {
                ViewResult view = new ViewResult();
                view.ViewName = "contact";
                filterContext.Result = view;
            }
            HttpContext.Current.Response.Write(bowserName+" "+userAddress);
        }
    }
}