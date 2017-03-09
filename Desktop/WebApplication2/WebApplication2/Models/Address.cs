using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Address
    {
        public string Street
        { get; set; }
        public string City
        { get; set; }
    }

    public class Employee
    {
        public string Name
        { get; set; }
        public Address ResAddress
        { get; set; }
        public Address OffAddress
        { get; set; }
        public string Photo { get; set; }
    }
}