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
    public class StudentSubjectController : Controller
    {
        private ControlSchoolEntities db = new ControlSchoolEntities();

        //
        // GET: /StudentSubject/

        public ActionResult Index()
        {
            var studentsubject = db.StudentSubject.Include(s => s.Student1).Include(s => s.Subject1);
            return View(studentsubject.ToList());
        }

        //
        // GET: /StudentSubject/Details/5

        public ActionResult Details(int id = 0)
        {
            StudentSubject studentsubject = db.StudentSubject.Find(id);
            if (studentsubject == null)
            {
                return HttpNotFound();
            }
            return View(studentsubject);
        }

        //
        // GET: /StudentSubject/Create

        public ActionResult Create()
        {
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name");
            ViewBag.Subject = new SelectList(db.Subject, "Subject1", "Subject1");
            return View();
        }

        //
        // POST: /StudentSubject/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentSubject studentsubject)
        {
            if (ModelState.IsValid)
            {
                db.StudentSubject.Add(studentsubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", studentsubject.Student);
            ViewBag.Subject = new SelectList(db.Subject, "Subject1", "Subject1", studentsubject.Subject);
            return View(studentsubject);
        }

        //
        // GET: /StudentSubject/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudentSubject studentsubject = db.StudentSubject.Find(id);
            if (studentsubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", studentsubject.Student);
            ViewBag.Subject = new SelectList(db.Subject, "Subject1", "Subject1", studentsubject.Subject);
            return View(studentsubject);
        }

        //
        // POST: /StudentSubject/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentSubject studentsubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", studentsubject.Student);
            ViewBag.Subject = new SelectList(db.Subject, "Subject1", "Subject1", studentsubject.Subject);
            return View(studentsubject);
        }

        //
        // GET: /StudentSubject/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudentSubject studentsubject = db.StudentSubject.Find(id);
            if (studentsubject == null)
            {
                return HttpNotFound();
            }
            return View(studentsubject);
        }

        //
        // POST: /StudentSubject/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentSubject studentsubject = db.StudentSubject.Find(id);
            db.StudentSubject.Remove(studentsubject);
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