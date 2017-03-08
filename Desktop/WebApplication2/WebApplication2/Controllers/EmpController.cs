using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(FormCollection fc)
        {
            DateTime startdate = DateTime.Now;
            List<Task<int>> lst = new List<Task<int>>();
            for (int i = 0; i < 1000; i++)
            {
                Task<int> op = Operation3();
                lst.Add(op);
            }
            await Task.WhenAll<int>(lst);
            await Operation4();
            ViewBag.totalTime = startdate - DateTime.Now;
            return View();
        }




        private async Task<int> Operation1()
        {
            await Task.Run(() => { Thread.Sleep(1000); });
            return 1;
        }
        private async Task<int> Operation2()
        {
            await Task.Run(() => { Thread.Sleep(1000); });
            return 2;
        }
        private async Task<int> Operation3()
        {
            await Task.Run(() => { Thread.Sleep(1000); });
            return 3;
        }
        private async Task<int> Operation4()
        {
            await Task.Run(() => { Thread.Sleep(30000); });
            return 4;
        }

        // GET: Emp/Details/5
        public ActionResult Details()
        {
            List<EmployeeModel> lstEmp = new List<EmployeeModel>()
            {
            new EmployeeModel() { EmpId=1,EmpName="Sandeep"},
            new Models.EmployeeModel() {EmpId=2,EmpName="Schott" }
            };
            return View(lstEmp);
        }

        public PartialViewResult Contact()
        {
            List<EmployeeModel> lstEmp = new List<EmployeeModel>()
            {
            new EmployeeModel() { EmpId=1,EmpName="Sandeep"},
            new Models.EmployeeModel() {EmpId=2,EmpName="Schott" }
            };
            return PartialView("_PartialHello", lstEmp);
        }

       
    }
}
