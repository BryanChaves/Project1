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
    public class QualificationController : Controller
    {
        private ControlSchoolEntities db = new ControlSchoolEntities();

        //
        // GET: /Qualification/

        public ActionResult Index()
        {
            var qualification = db.Qualification.Include(q => q.Student).Include(q => q.SubjectGroup);
            return View(qualification.ToList());
        }

        //
        // GET: /Qualification/Details/5

        public ActionResult Details(int id = 0)
        {
            Qualification qualification = db.Qualification.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        //
        // GET: /Qualification/Create

        public ActionResult Create()
        {
            ViewBag.idStudent = new SelectList(db.Student, "idStudent", "name");
            ViewBag.idSubjectGroup = new SelectList(db.SubjectGroup, "idSubjectGroup", "idSubjectGroup");
            return View();
        }

        //
        // POST: /Qualification/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Qualification.Add(qualification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idStudent = new SelectList(db.Student, "idStudent", "name", qualification.idStudent);
            ViewBag.idSubjectGroup = new SelectList(db.SubjectGroup, "idSubjectGroup", "idSubjectGroup", qualification.idSubjectGroup);
            return View(qualification);
        }

        //
        // GET: /Qualification/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Qualification qualification = db.Qualification.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            ViewBag.idStudent = new SelectList(db.Student, "idStudent", "name", qualification.idStudent);
            ViewBag.idSubjectGroup = new SelectList(db.SubjectGroup, "idSubjectGroup", "idSubjectGroup", qualification.idSubjectGroup);
            return View(qualification);
        }

        //
        // POST: /Qualification/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idStudent = new SelectList(db.Student, "idStudent", "name", qualification.idStudent);
            ViewBag.idSubjectGroup = new SelectList(db.SubjectGroup, "idSubjectGroup", "idSubjectGroup", qualification.idSubjectGroup);
            return View(qualification);
        }

        //
        // GET: /Qualification/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Qualification qualification = db.Qualification.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        //
        // POST: /Qualification/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qualification qualification = db.Qualification.Find(id);
            db.Qualification.Remove(qualification);
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