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
    public class StudentLevelController : Controller
    {
        private ControlSchoolEntities db = new ControlSchoolEntities();

        //
        // GET: /StudentLevel/

        public ActionResult Index()
        {
            var studentlevel = db.StudentLevel.Include(s => s.Student1);
            return View(studentlevel.ToList());
        }

        //
        // GET: /StudentLevel/Details/5

        public ActionResult Details(string id = null)
        {
            StudentLevel studentlevel = db.StudentLevel.Find(id);
            if (studentlevel == null)
            {
                return HttpNotFound();
            }
            return View(studentlevel);
        }

        //
        // GET: /StudentLevel/Create

        public ActionResult Create()
        {
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name");
            return View();
        }

        //
        // POST: /StudentLevel/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentLevel studentlevel)
        {
            if (ModelState.IsValid)
            {
                db.StudentLevel.Add(studentlevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", studentlevel.Student);
            return View(studentlevel);
        }

        //
        // GET: /StudentLevel/Edit/5

        public ActionResult Edit(string id = null)
        {
            StudentLevel studentlevel = db.StudentLevel.Find(id);
            if (studentlevel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", studentlevel.Student);
            return View(studentlevel);
        }

        //
        // POST: /StudentLevel/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentLevel studentlevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentlevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", studentlevel.Student);
            return View(studentlevel);
        }

        //
        // GET: /StudentLevel/Delete/5

        public ActionResult Delete(string id = null)
        {
            StudentLevel studentlevel = db.StudentLevel.Find(id);
            if (studentlevel == null)
            {
                return HttpNotFound();
            }
            return View(studentlevel);
        }

        //
        // POST: /StudentLevel/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentLevel studentlevel = db.StudentLevel.Find(id);
            db.StudentLevel.Remove(studentlevel);
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