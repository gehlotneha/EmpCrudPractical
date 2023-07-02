using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpCrudPractical.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage ="Please Enter Your Username")]
        [Display(Name ="Email :")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}