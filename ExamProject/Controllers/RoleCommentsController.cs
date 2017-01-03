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
    public class RoleCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoleComments
        public ActionResult Index()
        {
            return View(db.RoleComments.ToList());
        }

        // GET: RoleComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleComment roleComment = db.RoleComments.Find(id);
            if (roleComment == null)
            {
                return HttpNotFound();
            }
            return View(roleComment);
        }

        // GET: RoleComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Body,CompanyRoleId")] RoleComment roleComment)
        {
            roleComment.Commentator = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.RoleComments.Add(roleComment);
                db.SaveChanges();
                var test = roleComment.CompanyRoleId;
                return RedirectToAction("Details/" + test, "CompanyRoles");
            }

            return View();
        }

        // GET: RoleComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleComment roleComment = db.RoleComments.Find(id);
            if (roleComment == null)
            {
                return HttpNotFound();
            }
            return View(roleComment);
        }

        // POST: RoleComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleCommentId,Body")] RoleComment roleComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleComment);
        }

        // GET: RoleComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleComment roleComment = db.RoleComments.Find(id);
            if (roleComment == null)
            {
                return HttpNotFound();
            }
            return View(roleComment);
        }

        // POST: RoleComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleComment roleComment = db.RoleComments.Find(id);
            db.RoleComments.Remove(roleComment);
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
