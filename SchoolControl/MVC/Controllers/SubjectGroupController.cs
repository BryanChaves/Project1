using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos;

namespace MVC.Controllers
{
    public class SubjectGroupController : Controller
    {
        private ControlSchoolEntities db = new ControlSchoolEntities();

        //
        // GET: /SubjectGroup/

        public ActionResult Index()
        {
            var subjectgroup = db.SubjectGroup.Include(s => s.Group).Include(s => s.Subject).Include(s => s.Teacher);
            return View(subjectgroup.ToList());
        }

        //
        // GET: /SubjectGroup/Details/5

        public ActionResult Details(int id = 0)
        {
            SubjectGroup subjectgroup = db.SubjectGroup.Find(id);
            if (subjectgroup == null)
            {
                return HttpNotFound();
            }
            return View(subjectgroup);
        }

        //
        // GET: /SubjectGroup/Create

        public ActionResult Create()
        {
            ViewBag.idGroup = new SelectList(db.Group, "idGroup", "idGroup");
            ViewBag.idSubject = new SelectList(db.Subject, "idSubject", "name");
            ViewBag.idTeacher = new SelectList(db.Teacher, "idTeacher", "name");
            return View();
        }

        //
        // POST: /SubjectGroup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectGroup subjectgroup)
        {
            if (ModelState.IsValid)
            {
                db.SubjectGroup.Add(subjectgroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idGroup = new SelectList(db.Group, "idGroup", "idGroup", subjectgroup.idGroup);
            ViewBag.idSubject = new SelectList(db.Subject, "idSubject", "name", subjectgroup.idSubject);
            ViewBag.idTeacher = new SelectList(db.Teacher, "idTeacher", "name", subjectgroup.idTeacher);
            return View(subjectgroup);
        }

        //
        // GET: /SubjectGroup/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SubjectGroup subjectgroup = db.SubjectGroup.Find(id);
            if (subjectgroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.idGroup = new SelectList(db.Group, "idGroup", "idGroup", subjectgroup.idGroup);
            ViewBag.idSubject = new SelectList(db.Subject, "idSubject", "name", subjectgroup.idSubject);
            ViewBag.idTeacher = new SelectList(db.Teacher, "idTeacher", "name", subjectgroup.idTeacher);
            return View(subjectgroup);
        }

        //
        // POST: /SubjectGroup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectGroup subjectgroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectgroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idGroup = new SelectList(db.Group, "idGroup", "idGroup", subjectgroup.idGroup);
            ViewBag.idSubject = new SelectList(db.Subject, "idSubject", "name", subjectgroup.idSubject);
            ViewBag.idTeacher = new SelectList(db.Teacher, "idTeacher", "name", subjectgroup.idTeacher);
            return View(subjectgroup);
        }

        //
        // GET: /SubjectGroup/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SubjectGroup subjectgroup = db.SubjectGroup.Find(id);
            if (subjectgroup == null)
            {
                return HttpNotFound();
            }
            return View(subjectgroup);
        }

        //
        // POST: /SubjectGroup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectGroup subjectgroup = db.SubjectGroup.Find(id);
            db.SubjectGroup.Remove(subjectgroup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}