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
    public class ClassesController : Controller
    {
        private ControlSchoolEntities db = new ControlSchoolEntities();

        //
        // GET: /Classes/

        public ActionResult Index()
        {
            var classes = db.Classes.Include(c => c.Subject).Include(c => c.Teacher);
            return View(classes.ToList());
        }

        //
        // GET: /Classes/Details/5

        public ActionResult Details(int id = 0)
        {
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        //
        // GET: /Classes/Create

        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subject, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teacher, "Id", "Name");
            return View();
        }

        //
        // POST: /Classes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Classes classes)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(classes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.Subject, "Id", "Name", classes.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teacher, "Id", "Name", classes.TeacherId);
            return View(classes);
        }

        //
        // GET: /Classes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subject, "Id", "Name", classes.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teacher, "Id", "Name", classes.TeacherId);
            return View(classes);
        }

        //
        // POST: /Classes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Classes classes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subject, "Id", "Name", classes.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teacher, "Id", "Name", classes.TeacherId);
            return View(classes);
        }

        //
        // GET: /Classes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        //
        // POST: /Classes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classes classes = db.Classes.Find(id);
            db.Classes.Remove(classes);
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