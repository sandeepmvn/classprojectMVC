using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Address
    {
        public string Street
        { get; set; }
        public string City
        { get; set; }
    }
    [ModelBinder(typeof(CustomEmployeeBinder))]
    public class Employee
    {
        public string Name
        { get; set; }
        public Address ResAddress
        { get; set; }
        public Address OffAddress
        { get; set; }
        public string Photo { get; set; }
        public int Age { get; set; }
    }

}