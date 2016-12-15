using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; } // file upload, base64 or a link?
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<CompanyRole> CompanyRoles { get; set; }
        public virtual List<ApplicationUser> Employees { get; set; }
        public virtual List<Achievement> Achievements { get; set; }
    }
}