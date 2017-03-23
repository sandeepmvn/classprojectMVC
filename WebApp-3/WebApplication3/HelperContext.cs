using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class HelperContext
    {
        public static WebDemoEntities GetContext()
        {
            if (HttpContext.Current.Items["context"] == null)
                HttpContext.Current.Items.Add("context", new WebDemoEntities());
            return (WebDemoEntities)HttpContext.Current.Items["context"];
        }
    }
}