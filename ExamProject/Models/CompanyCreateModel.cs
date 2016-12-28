using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class CompanyCreateModel
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public HttpPostedFileBase Logo { get; set; }
    }
}