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
            var studentsubject = db.StudentSubject.Include(s => s.Result).Include(s => s.Student).Include(s => s.Subject);
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
            ViewBag.id_result = new SelectList(db.Result, "id_result", "id_result");
            ViewBag.id_student = new SelectList(db.Student, "id_student", "name");
            ViewBag.id_subject = new SelectList(db.Subject, "id_subject", "name");
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

            ViewBag.id_result = new SelectList(db.Result, "id_result", "id_result", studentsubject.id_result);
            ViewBag.id_student = new SelectList(db.Student, "id_student", "name", studentsubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subject, "id_subject", "name", studentsubject.id_subject);
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
            ViewBag.id_result = new SelectList(db.Result, "id_result", "id_result", studentsubject.id_result);
            ViewBag.id_student = new SelectList(db.Student, "id_student", "name", studentsubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subject, "id_subject", "name", studentsubject.id_subject);
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
            ViewBag.id_result = new SelectList(db.Result, "id_result", "id_result", studentsubject.id_result);
            ViewBag.id_student = new SelectList(db.Student, "id_student", "name", studentsubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subject, "id_subject", "name", studentsubject.id_subject);
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