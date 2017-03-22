using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Repositories;

namespace WebApplication3.BO
{
    public interface IEmployeeBO
    {
        IEnumerable<Employee> GetEmployess();
        Employee GetEmployee(int empId);
        void InsertEmployee(Employee objEmployee);
        void UpdateEmployee(Employee objEmployee);
        void DeleteEmployee(int empId);
    }

    public class EmployeeBO:IEmployeeBO
    {
        IRepository<Employee> repEmp;
        public EmployeeBO() : this(new GenericRepository<Employee>())
        { }
        public EmployeeBO(IRepository<Employee> Emprep)
        {
            repEmp = Emprep;
        }
        public IEnumerable<Employee> GetEmployess()
        {
            return repEmp.GetAll();
        }

        public Employee GetEmployee(int empId)
        {
            return repEmp.GetAll().Where(e => e.EmpId == empId).SingleOrDefault();
        }

        public void InsertEmployee(Employee objEmployee)
        {
            repEmp.Insert(objEmployee);
        }

        public void UpdateEmployee(Employee objEmployee)
        {
            repEmp.Update(objEmployee);
        }

        public void DeleteEmployee(int empId)
        {
            repEmp.Delete(empId);
        }

    }
}