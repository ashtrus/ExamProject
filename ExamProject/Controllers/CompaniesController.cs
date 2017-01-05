using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamProject.Models;
using Microsoft.AspNet.Identity;

namespace ExamProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Companies
        public ActionResult Index()
        {
            var myId = User.Identity.GetUserId();
            // return companies that I am an admin on.
            return View(db.Companies.Where(x => x.Administrators.Any(a => a.Id == myId)).ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }


        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CompanyCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var company = new Company
                {
                    
                };
                if (model.Logo != null)
                {
                    // handle logo
                    var folderGuid = Guid.NewGuid().ToString();
                    var imagesPath = Path.Combine(Server.MapPath("~/UploadedImages/"), folderGuid);
                    if (!Directory.Exists(imagesPath))
                    {
                        Directory.CreateDirectory(imagesPath);
                    }

                    var imagePath = Path.Combine(imagesPath, model.Logo.FileName);
                    model.Logo.SaveAs(imagePath);
                    company.Logo = string.Concat("/UploadedImages/", folderGuid, "/", model.Logo.FileName);
                }

                company.Name = model.Name;
                company.Email = model.Email;
                company.Phone = model.Phone;


                db.Companies.Add(company);
                // find logged in user
                var myId = User.Identity.GetUserId();
                var me = db.Users.First(x => x.Id == myId);
                // add this user to admins
                if (company.Administrators == null)
                    company.Administrators = new List<ApplicationUser>();
                company.Administrators.Add(me);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            var myId = User.Identity.GetUserId();
            if (company.Administrators.All(x => x.Id != myId))
                return new HttpUnauthorizedResult("no luck");

            return View(CompanyCreateModel.Init(company));
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var company = db.Companies.First(x => x.CompanyId == model.CompanyId);
                var myId = User.Identity.GetUserId();
                if (company.Administrators.All(x => x.Id != myId))
                    return new HttpUnauthorizedResult("no luck");

                if (model.Logo != null)
                {
                    // handle logo
                    var folderGuid = Guid.NewGuid().ToString();
                    var imagesPath = Path.Combine(Server.MapPath("~/UploadedImages/"), folderGuid);
                    if (!Directory.Exists(imagesPath))
                    {
                        Directory.CreateDirectory(imagesPath);
                    }

                    var imagePath = Path.Combine(imagesPath, model.Logo.FileName);
                    model.Logo.SaveAs(imagePath);
                    company.Logo = string.Concat("/UploadedImages/", folderGuid, "/", model.Logo.FileName);
                }

                company.Name = model.Name;
                company.Email = model.Email;
                company.Phone = model.Phone;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            var myId = User.Identity.GetUserId();
            if (company.Administrators.All(x => x.Id != myId))
            {
                return Content("No luck sinjor... Need to be an admin!!!");
            }
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
