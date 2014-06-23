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
    public class SectionLevelController : Controller
    {
        private ControlSchoolEntities db = new ControlSchoolEntities();

        //
        // GET: /SectionLevel/

        public ActionResult Index()
        {
            var sectionlevel = db.SectionLevel.Include(s => s.Level1).Include(s => s.Section1);
            return View(sectionlevel.ToList());
        }

        //
        // GET: /SectionLevel/Details/5

        public ActionResult Details(int id = 0)
        {
            SectionLevel sectionlevel = db.SectionLevel.Find(id);
            if (sectionlevel == null)
            {
                return HttpNotFound();
            }
            return View(sectionlevel);
        }

        //
        // GET: /SectionLevel/Create

        public ActionResult Create()
        {
            ViewBag.Level = new SelectList(db.Level, "Level1", "Level1");
            ViewBag.Section = new SelectList(db.Section, "Section1", "Section1");
            return View();
        }

        //
        // POST: /SectionLevel/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectionLevel sectionlevel)
        {
            if (ModelState.IsValid)
            {
                db.SectionLevel.Add(sectionlevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Level = new SelectList(db.Level, "Level1", "Level1", sectionlevel.Level);
            ViewBag.Section = new SelectList(db.Section, "Section1", "Section1", sectionlevel.Section);
            return View(sectionlevel);
        }

        //
        // GET: /SectionLevel/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SectionLevel sectionlevel = db.SectionLevel.Find(id);
            if (sectionlevel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Level = new SelectList(db.Level, "Level1", "Level1", sectionlevel.Level);
            ViewBag.Section = new SelectList(db.Section, "Section1", "Section1", sectionlevel.Section);
            return View(sectionlevel);
        }

        //
        // POST: /SectionLevel/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SectionLevel sectionlevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sectionlevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Level = new SelectList(db.Level, "Level1", "Level1", sectionlevel.Level);
            ViewBag.Section = new SelectList(db.Section, "Section1", "Section1", sectionlevel.Section);
            return View(sectionlevel);
        }

        //
        // GET: /SectionLevel/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SectionLevel sectionlevel = db.SectionLevel.Find(id);
            if (sectionlevel == null)
            {
                return HttpNotFound();
            }
            return View(sectionlevel);
        }

        //
        // POST: /SectionLevel/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SectionLevel sectionlevel = db.SectionLevel.Find(id);
            db.SectionLevel.Remove(sectionlevel);
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