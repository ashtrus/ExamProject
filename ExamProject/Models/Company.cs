using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; } // file upload, base64 or a link?

        public List<Role> Roles { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Achievement> Achievements = new List<Achievement>();



    }
}