using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1final.Models;

namespace WebApplication1final.Controllers
{
    public class NeglectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Neglects
        public ActionResult Index()
        {
            return View(db.Neglects.ToList());
        }

        // GET: Neglects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neglect neglect = db.Neglects.Find(id);
            if (neglect == null)
            {
                return HttpNotFound();
            }
            return View(neglect);
        }

        // GET: Neglects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Neglects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Food,Shelter,Abandoned,Poison,Underweight,Trapping,Water,Shot,Injury,Abuse,Other")] Neglect neglect)
        {
            if (ModelState.IsValid)
            {
                db.Neglects.Add(neglect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(neglect);
        }

        // GET: Neglects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neglect neglect = db.Neglects.Find(id);
            if (neglect == null)
            {
                return HttpNotFound();
            }
            return View(neglect);
        }

        // POST: Neglects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Food,Shelter,Abandoned,Poison,Underweight,Trapping,Water,Shot,Injury,Abuse,Other")] Neglect neglect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(neglect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(neglect);
        }

        // GET: Neglects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neglect neglect = db.Neglects.Find(id);
            if (neglect == null)
            {
                return HttpNotFound();
            }
            return View(neglect);
        }

        // POST: Neglects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Neglect neglect = db.Neglects.Find(id);
            db.Neglects.Remove(neglect);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
