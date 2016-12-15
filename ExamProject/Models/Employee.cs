using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ExamProject.Models
{
    public class Employee 
    {
  
        public int EmployeeId { get; set; } //primary key
        // [Required(ErrorMessage = "FirstName is requiered")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is requiered")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Email is requiered")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; } // file upload

        public virtual ICollection<SkillExperience> SkillExperience { get; set; }
        public virtual ICollection<CompanyRole> CompanyRoles { get; set; }

        public virtual Skill Skill { get; set; }  // relationship

        public CompanyRole[] CurrentRoles = new CompanyRole[3];  // show level for each skill. how??

    }
}