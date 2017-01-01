using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamProject.Models;

namespace ExamProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {

        //// GET: Experience
        //public ActionResult Index()
        //{
        //    var db = new ApplicationDbContext();



        //    return View();
        //}

        public ActionResult ForCompany(int id)
        {
            var db = new ApplicationDbContext();

            var company = db.Companies.FirstOrDefault(x => x.CompanyId == id);

            if (company == null) return HttpNotFound();
            var experiences = new List<SkillExperience>();


            var employees = company.Employees;
            foreach (var employee in employees)
            {
                if (employee.SkillExperience.Any())
                    experiences.AddRange(employee.SkillExperience);
            }
            return View(experiences);
        }

    }
}