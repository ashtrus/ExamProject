using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class Employee 
    {
        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; } // file upload

        public Role[] CurrentRoles = new Role[3];  // show level for each skill. how??

    }
}