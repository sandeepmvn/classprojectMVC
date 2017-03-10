using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2
{
    public class CustomEmployeeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Employee employee;
            if (bindingContext.Model == null)
            {
                employee = new Employee();
                employee.OffAddress = new Address();
                employee.ResAddress = new Address();
            }
            else
            {
                employee = (Employee)bindingContext.Model;
            }
            employee.Name = GetValue<string>(bindingContext, "Name");
            //employee.Age = GetValue<int>(bindingContext, "Age");
            employee.OffAddress.Street = GetValue<string>(bindingContext, "OffAddressStreet");
            employee.OffAddress.City = GetValue<string>(bindingContext, "OffAddressCity");
            employee.ResAddress.Street=GetValue<string>(bindingContext, "ResAddressStreet");
            employee.ResAddress.City = GetValue<string>(bindingContext, "ResAddressCity");
            return employee;
        }


        private T GetValue<T>(ModelBindingContext bindingContext, string key)
        {
            //At runtime the MVC framework populates the ValueProvider with values it finds in the request’s form, route, and query string collections.
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(key);
            bindingContext.ModelState.SetModelValue(key, valueResult); //**
            return (T)valueResult.ConvertTo(typeof(T));
        }
    }
}