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
    public class ReportLocalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReportLocals
        public ActionResult Index()
        {
            return View(db.ReportLocals.ToList());
        }

        // GET: ReportLocals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportLocal reportLocal = db.ReportLocals.Find(id);
            if (reportLocal == null)
            {
                return HttpNotFound();
            }
            return View(reportLocal);
        }

        // GET: ReportLocals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportLocals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AbuserDescription,PropertyDescription,OwnerName,AnimalDescription")] ReportLocal reportLocal)
        {
            if (ModelState.IsValid)
            {
                db.ReportLocals.Add(reportLocal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportLocal);
        }

        // GET: ReportLocals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportLocal reportLocal = db.ReportLocals.Find(id);
            if (reportLocal == null)
            {
                return HttpNotFound();
            }
            return View(reportLocal);
        }

        // POST: ReportLocals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AbuserDescription,PropertyDescription,OwnerName,AnimalDescription")] ReportLocal reportLocal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportLocal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportLocal);
        }

        // GET: ReportLocals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportLocal reportLocal = db.ReportLocals.Find(id);
            if (reportLocal == null)
            {
                return HttpNotFound();
            }
            return View(reportLocal);
        }

        // POST: ReportLocals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportLocal reportLocal = db.ReportLocals.Find(id);
            db.ReportLocals.Remove(reportLocal);
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
