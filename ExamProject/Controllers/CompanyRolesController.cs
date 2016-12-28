using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamProject.Models;

namespace ExamProject.Controllers
{
    public class CompanyRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyRoles
        [Authorize]
        public ActionResult Index()
        {
            var companyRoles = db.CompanyRoles.Include(c => c.Company);
            return View(companyRoles.ToList());
        }

        // GET: CompanyRoles/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRole companyRole = db.CompanyRoles.Find(id);
            if (companyRole == null)
            {
                return HttpNotFound();
            }
            return View(companyRole);
        }

        // GET: CompanyRoles/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name");
            return View();
        }

        // POST: CompanyRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,CompanyId")] CompanyRole companyRole)
        {
            companyRole.SelectedOn = DateTime.Now;
            //companyRole.CompanyId = (Session["Company"] as Company).CompanyId; //get company ID from the company object in the session
            if (ModelState.IsValid)
            {
                db.CompanyRoles.Add(companyRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", companyRole.CompanyId);
            return View(companyRole);
        }

        // GET: CompanyRoles/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRole companyRole = db.CompanyRoles.Find(id);
            if (companyRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", companyRole.CompanyId);
            return View(companyRole);
        }

        // POST: CompanyRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyRoleId,Title,Description,SelectedOn,CompanyId")] CompanyRole companyRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", companyRole.CompanyId);
            return View(companyRole);
        }

        // GET: CompanyRoles/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRole companyRole = db.CompanyRoles.Find(id);
            if (companyRole == null)
            {
                return HttpNotFound();
            }
            return View(companyRole);
        }

        // POST: CompanyRoles/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyRole companyRole = db.CompanyRoles.Find(id);
            db.CompanyRoles.Remove(companyRole);
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
