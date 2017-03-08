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
    public class ReportAbusesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReportAbuses
        public ActionResult Index()
        {
            var reportAbuses = db.ReportAbuses.Include(r => r.Neglect).Include(r => r.ReportLocal);
            return View(reportAbuses.ToList());
        }

        // GET: ReportAbuses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportAbuse reportAbuse = db.ReportAbuses.Find(id);
            if (reportAbuse == null)
            {
                return HttpNotFound();
            }
            return View(reportAbuse);
        }

        // GET: ReportAbuses/Create
        public ActionResult Create()
        {
            ViewBag.NeglectID = new SelectList(db.Neglects, "ID", "Other");
            ViewBag.LocalID = new SelectList(db.ReportLocals, "ID", "AbuserDescription");
            return View();
        }

        // POST: ReportAbuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportID,Topic,FullName,ReportEmail,ReportPhone,Contact,Updates,LocalID,NeglectID")] ReportAbuse reportAbuse)
        {
            if (ModelState.IsValid)
            {
                db.ReportAbuses.Add(reportAbuse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NeglectID = new SelectList(db.Neglects, "ID", "Other", reportAbuse.NeglectID);
            ViewBag.LocalID = new SelectList(db.ReportLocals, "ID", "AbuserDescription", reportAbuse.LocalID);
            return View(reportAbuse);
        }

        // GET: ReportAbuses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportAbuse reportAbuse = db.ReportAbuses.Find(id);
            if (reportAbuse == null)
            {
                return HttpNotFound();
            }
            ViewBag.NeglectID = new SelectList(db.Neglects, "ID", "Other", reportAbuse.NeglectID);
            ViewBag.LocalID = new SelectList(db.ReportLocals, "ID", "AbuserDescription", reportAbuse.LocalID);
            return View(reportAbuse);
        }

        // POST: ReportAbuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportID,Topic,FullName,ReportEmail,ReportPhone,Contact,Updates,LocalID,NeglectID")] ReportAbuse reportAbuse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportAbuse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NeglectID = new SelectList(db.Neglects, "ID", "Other", reportAbuse.NeglectID);
            ViewBag.LocalID = new SelectList(db.ReportLocals, "ID", "AbuserDescription", reportAbuse.LocalID);
            return View(reportAbuse);
        }

        // GET: ReportAbuses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportAbuse reportAbuse = db.ReportAbuses.Find(id);
            if (reportAbuse == null)
            {
                return HttpNotFound();
            }
            return View(reportAbuse);
        }

        // POST: ReportAbuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportAbuse reportAbuse = db.ReportAbuses.Find(id);
            db.ReportAbuses.Remove(reportAbuse);
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
