using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpCrudPractical.Models
{
    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Languages { get; set; }
        public string Remarks { get; set; }
    }
}