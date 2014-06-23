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
    public class ResultSubjectStudentController : Controller
    {
        private ControlSchoolEntities db = new ControlSchoolEntities();

        //
        // GET: /ResultSubjectStudent/

        public ActionResult Index()
        {
            var resultsubjectstudent = db.ResultSubjectStudent.Include(r => r.Result1).Include(r => r.Student1).Include(r => r.Subject1);
            return View(resultsubjectstudent.ToList());
        }

        //
        // GET: /ResultSubjectStudent/Details/5

        public ActionResult Details(int id = 0)
        {
            ResultSubjectStudent resultsubjectstudent = db.ResultSubjectStudent.Find(id);
            if (resultsubjectstudent == null)
            {
                return HttpNotFound();
            }
            return View(resultsubjectstudent);
        }


        //Search


        public ActionResult Search(String Name)
        {
            var Student = from s in db.ResultSubjectStudent select s;
            if (!String.IsNullOrEmpty(Name))
            {
                Student = Student.Where(j => j.Student1.Name.Contains(Name));
            }
            return View(Student);
        }














        //
        // GET: /ResultSubjectStudent/Create

        public ActionResult Create()
        {
            ViewBag.Result = new SelectList(db.Result, "Result1", "Result1");
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name");
            ViewBag.Subject = new SelectList(db.Subject, "Subject1", "Subject1");
            return View();
        }

        //
        // POST: /ResultSubjectStudent/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResultSubjectStudent resultsubjectstudent)
        {
            if (ModelState.IsValid)
            {
                db.ResultSubjectStudent.Add(resultsubjectstudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Result = new SelectList(db.Result, "Result1", "Result1", resultsubjectstudent.Result);
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", resultsubjectstudent.Student);
            ViewBag.Subject = new SelectList(db.Subject, "Subject1", "Subject1", resultsubjectstudent.Subject);
            return View(resultsubjectstudent);
        }

        //
        // GET: /ResultSubjectStudent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ResultSubjectStudent resultsubjectstudent = db.ResultSubjectStudent.Find(id);
            if (resultsubjectstudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.Result = new SelectList(db.Result, "Result1", "Result1", resultsubjectstudent.Result);
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", resultsubjectstudent.Student);
            ViewBag.Subject = new SelectList(db.Subject, "Subject1", "Subject1", resultsubjectstudent.Subject);
            return View(resultsubjectstudent);
        }

        //
        // POST: /ResultSubjectStudent/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResultSubjectStudent resultsubjectstudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultsubjectstudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Result = new SelectList(db.Result, "Result1", "Result1", resultsubjectstudent.Result);
            ViewBag.Student = new SelectList(db.Student, "Identification", "Name", resultsubjectstudent.Student);
            ViewBag.Subject = new SelectList(db.Subject, "Subject1", "Subject1", resultsubjectstudent.Subject);
            return View(resultsubjectstudent);
        }

        //
        // GET: /ResultSubjectStudent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ResultSubjectStudent resultsubjectstudent = db.ResultSubjectStudent.Find(id);
            if (resultsubjectstudent == null)
            {
                return HttpNotFound();
            }
            return View(resultsubjectstudent);
        }

        //
        // POST: /ResultSubjectStudent/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResultSubjectStudent resultsubjectstudent = db.ResultSubjectStudent.Find(id);
            db.ResultSubjectStudent.Remove(resultsubjectstudent);
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