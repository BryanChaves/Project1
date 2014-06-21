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
    public class StudentClassesController : Controller
    {
        private ControlSchoolEntities db = new ControlSchoolEntities();

        //
        // GET: /StudentClasses/

        public ActionResult Index()
        {
            var studentclasses = db.StudentClasses.Include(s => s.Classes).Include(s => s.Student);
            return View(studentclasses.ToList());
        }

        //
        // GET: /StudentClasses/Details/5

        public ActionResult Details(int id = 0)
        {
            StudentClasses studentclasses = db.StudentClasses.Find(id);
            if (studentclasses == null)
            {
                return HttpNotFound();
            }
            return View(studentclasses);
        }

        //
        // GET: /StudentClasses/Create

        public ActionResult Create()
        {
            ViewBag.id_class = new SelectList(db.Classes, "id_class", "id_class");
            ViewBag.id_student = new SelectList(db.Student, "id_student", "name");
            return View();
        }

        //
        // POST: /StudentClasses/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentClasses studentclasses)
        {
            if (ModelState.IsValid)
            {
                db.StudentClasses.Add(studentclasses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_class = new SelectList(db.Classes, "id_class", "id_class", studentclasses.id_class);
            ViewBag.id_student = new SelectList(db.Student, "id_student", "name", studentclasses.id_student);
            return View(studentclasses);
        }

        //
        // GET: /StudentClasses/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudentClasses studentclasses = db.StudentClasses.Find(id);
            if (studentclasses == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_class = new SelectList(db.Classes, "id_class", "id_class", studentclasses.id_class);
            ViewBag.id_student = new SelectList(db.Student, "id_student", "name", studentclasses.id_student);
            return View(studentclasses);
        }

        //
        // POST: /StudentClasses/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentClasses studentclasses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentclasses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_class = new SelectList(db.Classes, "id_class", "id_class", studentclasses.id_class);
            ViewBag.id_student = new SelectList(db.Student, "id_student", "name", studentclasses.id_student);
            return View(studentclasses);
        }

        //
        // GET: /StudentClasses/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudentClasses studentclasses = db.StudentClasses.Find(id);
            if (studentclasses == null)
            {
                return HttpNotFound();
            }
            return View(studentclasses);
        }

        //
        // POST: /StudentClasses/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentClasses studentclasses = db.StudentClasses.Find(id);
            db.StudentClasses.Remove(studentclasses);
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