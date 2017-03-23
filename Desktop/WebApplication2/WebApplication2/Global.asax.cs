using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            Exception ex = Context.Error;
            if (ex is ApplicationException)
            {
                Response.Write("Application_Error: " + ex.Message);
                Context.ClearError(); //Further processing of error is stopped.
            }
        }


        protected void Application_AuthenticateRequest(object sender, EventArgs args)
        {
            if (Request.IsAuthenticated)
            {
                string[] roles = null;
                switch (User.Identity.Name)
                {
                    case "Admin":
                        roles = new string[] { "Create", "Edit", "Delete", "View" };
                        break;
                    case "u1":
                        roles = new string[] { "Edit", "Delete", "View" };
                        break;
                    case "u2":
                        roles = new string[] { "View" };
                        break;
                }
            Context.User = new System.Security.Principal.GenericPrincipal(User.Identity, roles);
            }
        }
    }
}
