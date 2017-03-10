using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class UserProfile
    {

        [Required(ErrorMessage = "User Name is Required")]
        [Display(Name="Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType("password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "DateOfBirth is Required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter valid Email Id")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Rating is Required")]
        [Range(1, 10)]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [Display(Name = "Phone Number")]
        public int PhoneNo { get; set; }
        [Required(ErrorMessage = "Comments is Required")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public string Photo { get; set; }
    }
}