using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class CompanyCreateModel
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public HttpPostedFileBase Logo { get; set; }

        /// <summary>
        /// Holds the value of the path to the logo file when editing
        /// </summary>
        public string LogoPath { get; set; }

        public static CompanyCreateModel Init(Company company)
        {
            var res = new CompanyCreateModel();

            if (company == null) return res;

            res.Name = company.Name;
            res.CompanyId = company.CompanyId;
            res.Email = company.Email;
            res.Phone = company.Phone;

            res.LogoPath = company.Logo;
            return res;
        }
    }
}