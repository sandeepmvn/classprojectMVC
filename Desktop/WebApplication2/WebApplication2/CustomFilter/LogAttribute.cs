using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class LogAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Trace(filterContext.RouteData, "OnActionExecuting");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Trace(filterContext.RouteData, "OnActionExecuted");
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Trace(filterContext.RouteData, "OnResultExecuting");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Trace(filterContext.RouteData, "OnResultExecuted");
        }
        private void Trace(RouteData routes,string methodName)
        {
            var controller = routes.Values["controller"];
            var action = routes.Values["action"];
            HttpContext.Current.Response.Write("&nbsp&nbsp 1"+methodName+" "+ controller + " " + action+"<br/>");
        }
    }

    public class Log2Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           /* filterContext.Result = new EmptyResult()*/;
            Trace(filterContext.RouteData, "OnActionExecuting");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Trace(filterContext.RouteData, "OnActionExecuted");
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Cancel = true;
            Trace(filterContext.RouteData, "OnResultExecuting");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Trace(filterContext.RouteData, "OnResultExecuted");
        }
        private void Trace(RouteData routes, string methodName)
        {
            var controller = routes.Values["controller"];
            var action = routes.Values["action"];
            HttpContext.Current.Response.Write("&nbsp&nbsp 2" + methodName + " " + controller + " " + action + "<br/>");
        }
    }
}