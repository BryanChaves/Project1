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
    public class StudentSectionController : Controller
    {
        private ControlSchoolEntities db = new ControlSchoolEntities();

        //
        // GET: /StudentSection/

        public ActionResult Index()
        {
            var studentsection = db.StudentSection.Include(s => s.Section1).Include(s => s.Student1);
            return View(studentsection.ToList());
        }

        //
        // GET: /StudentSection/Details/5

        public ActionResult Details(int id = 0)
        {
            StudentSection studentsection = db.StudentSection.Find(id);
            if (studentsection == null)
            {
                return HttpNotFound();
            }
            return View(studentsection);
        }

        //
        // GET: /StudentSection/Create

        public ActionResult Create()
        {
            ViewBag.Section = new SelectList(db.Section, "Section1", "Section1");
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name");
            return View();
        }

        //
        // POST: /StudentSection/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentSection studentsection)
        {
            if (ModelState.IsValid)
            {
                db.StudentSection.Add(studentsection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Section = new SelectList(db.Section, "Section1", "Section1", studentsection.Section);
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", studentsection.Student);
            return View(studentsection);
        }

        //
        // GET: /StudentSection/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudentSection studentsection = db.StudentSection.Find(id);
            if (studentsection == null)
            {
                return HttpNotFound();
            }
            ViewBag.Section = new SelectList(db.Section, "Section1", "Section1", studentsection.Section);
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", studentsection.Student);
            return View(studentsection);
        }

        //
        // POST: /StudentSection/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentSection studentsection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Section = new SelectList(db.Section, "Section1", "Section1", studentsection.Section);
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", studentsection.Student);
            return View(studentsection);
        }

        //
        // GET: /StudentSection/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudentSection studentsection = db.StudentSection.Find(id);
            if (studentsection == null)
            {
                return HttpNotFound();
            }
            return View(studentsection);
        }

        //
        // POST: /StudentSection/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentSection studentsection = db.StudentSection.Find(id);
            db.StudentSection.Remove(studentsection);
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