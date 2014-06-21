using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace MVC.Controllers
{
    public class TeacherSubjectController : Controller
    {
        private ControlSchoolEntities db = new ControlSchoolEntities();

        //
        // GET: /TeacherSubject/

        public ActionResult Index()
        {
            var teachersubject = db.TeacherSubject.Include(t => t.Subject).Include(t => t.Teacher);
            return View(teachersubject.ToList());
        }

        //
        // GET: /TeacherSubject/Details/5

        public ActionResult Details(int id = 0)
        {
            TeacherSubject teachersubject = db.TeacherSubject.Find(id);
            if (teachersubject == null)
            {
                return HttpNotFound();
            }
            return View(teachersubject);
        }

        //
        // GET: /TeacherSubject/Create

        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subject, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teacher, "Id", "Name");
            return View();
        }

        //
        // POST: /TeacherSubject/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherSubject teachersubject)
        {
            if (ModelState.IsValid)
            {
                db.TeacherSubject.Add(teachersubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.Subject, "Id", "Name", teachersubject.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teacher, "Id", "Name", teachersubject.TeacherId);
            return View(teachersubject);
        }

        //
        // GET: /TeacherSubject/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TeacherSubject teachersubject = db.TeacherSubject.Find(id);
            if (teachersubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subject, "Id", "Name", teachersubject.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teacher, "Id", "Name", teachersubject.TeacherId);
            return View(teachersubject);
        }

        //
        // POST: /TeacherSubject/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherSubject teachersubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachersubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subject, "Id", "Name", teachersubject.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teacher, "Id", "Name", teachersubject.TeacherId);
            return View(teachersubject);
        }

        //
        // GET: /TeacherSubject/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TeacherSubject teachersubject = db.TeacherSubject.Find(id);
            if (teachersubject == null)
            {
                return HttpNotFound();
            }
            return View(teachersubject);
        }

        //
        // POST: /TeacherSubject/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherSubject teachersubject = db.TeacherSubject.Find(id);
            db.TeacherSubject.Remove(teachersubject);
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