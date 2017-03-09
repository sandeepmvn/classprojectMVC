using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Student
    {
        public int Id { get; set; }
        [UIHint("SayHello")]
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfJoin { get; set; }
        public StudentsType TypeOfStudent { get; set; }
    }

    public enum StudentsType
    {
    Junior=1,
    Senior=2 
    }

}