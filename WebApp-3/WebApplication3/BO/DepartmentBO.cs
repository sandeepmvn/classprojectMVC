using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Repositories;

namespace WebApplication3.BO
{
    public class DepartmentBO
    {
        GenericRepository<Department> repDept = new GenericRepository<Department>();
        public IEnumerable<Department> GetDepartments()
        {
            return repDept.GetAll();
        }

        public Department GetDepartment(int deptId)
        {
            return repDept.GetAll().Where(d => d.DeptId == deptId).SingleOrDefault();
        }
    }
}