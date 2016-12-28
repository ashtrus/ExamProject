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
    public class SkillExperiencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SkillExperiences
        [Authorize]
        public ActionResult Index()
        {
            var skillExperiences = db.SkillExperiences.Include(s => s.Skill);
            return View(skillExperiences.ToList());
        }

        // GET: SkillExperiences/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillExperience skillExperience = db.SkillExperiences.Find(id);
            if (skillExperience == null)
            {
                return HttpNotFound();
            }
            return View(skillExperience);
        }

        // GET: SkillExperiences/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.SkillId = new SelectList(db.Skills, "SkillId", "Name");
            return View();
        }

        // POST: SkillExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkillExperienceId,SkillId,Experience")] SkillExperience skillExperience)
        {
            if (ModelState.IsValid)
            {
                db.SkillExperiences.Add(skillExperience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SkillId = new SelectList(db.Skills, "SkillId", "Name", skillExperience.SkillId);
            return View(skillExperience);
        }

        // GET: SkillExperiences/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillExperience skillExperience = db.SkillExperiences.Find(id);
            if (skillExperience == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkillId = new SelectList(db.Skills, "SkillId", "Name", skillExperience.SkillId);
            return View(skillExperience);
        }

        // POST: SkillExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkillExperienceId,SkillId,Experience")] SkillExperience skillExperience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skillExperience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkillId = new SelectList(db.Skills, "SkillId", "Name", skillExperience.SkillId);
            return View(skillExperience);
        }

        // GET: SkillExperiences/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillExperience skillExperience = db.SkillExperiences.Find(id);
            if (skillExperience == null)
            {
                return HttpNotFound();
            }
            return View(skillExperience);
        }

        // POST: SkillExperiences/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkillExperience skillExperience = db.SkillExperiences.Find(id);
            db.SkillExperiences.Remove(skillExperience);
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
