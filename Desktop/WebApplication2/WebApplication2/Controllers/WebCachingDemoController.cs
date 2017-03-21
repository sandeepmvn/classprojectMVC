using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class WebCachingDemoController : Controller
    {
        // GET: WebCachingDemo
        [OutputCache(CacheProfile = "CacheInConfig")]
        // [OutputCache(Duration = 100,VaryByCustom ="Browser",VaryByHeader ="Referer",NoStore =true)]
        public ActionResult Index()
        {
            DateTime dt;
            dt = DateTime.Now;
            Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(100)); //For setting the absolute Data and Time.
                                                                     //Response.Cache.SetMaxAge(new TimeSpan(0, 0, 10)); //For mentioning the relative Data and Time.
            Response.Cache.VaryByHeaders["referer"] = true;
            Response.Cache.VaryByParams["user"] = true;
            Response.Cache.SetValidUntilExpires(true);

            ViewBag.Referer = Request.UrlReferrer;
            ViewBag.Date = DateTime.Now;
            return View();
        }
        [OutputCache(Duration = 100, VaryByParam = "userName")]
        [HttpPost]
        public ActionResult Index(string userName)
        {
            ViewBag.Date = DateTime.Now + " " + userName;
            return View();
        }



        public ActionResult MemoryCacheDemo()
        {
            ObjectCache cache = MemoryCache.Default;
            DateTime dt;
            if (cache["systime"] == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTime.Now.AddSeconds(40);
                // policy.SlidingExpiration = new TimeSpan(0, 0, 40);
                cache.Add("systime", DateTime.Now, policy);
            }
            dt = (DateTime)cache["systime"];
            return Content(dt.ToLongTimeString());
        }


        public ActionResult CachingDemo()
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache["testData"] == null)
            {
                string path = Server.MapPath("~/Content/Test.txt");
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = DateTime.Now.AddSeconds(200);
                    ChangeMonitor files = new HostFileChangeMonitor(new List<string> { path });
                    policy.ChangeMonitors.Add(files);
                    cache.Add("testData", sr.ReadToEnd(), policy);
                }

            }
            return Content(cache["testData"].ToString());
        }

    }
}