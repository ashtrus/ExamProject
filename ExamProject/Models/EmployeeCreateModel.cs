using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class EmployeeCreateModel
    {
        public int EmployeeId { get; set; } //primary key
        // [Required(ErrorMessage = "FirstName is requiered")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is requiered")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Email is requiered")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public HttpPostedFileBase Picture { get; set; } // file upload
    }
}