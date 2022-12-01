using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentMSystem.Models;

namespace StudentMSystem.Controllers
{
    public class usertblsController : Controller
    {
        private StudenSystemEntities1 db = new StudenSystemEntities1();

        // GET: usertbls
        public ActionResult Index()
        {
            return View(db.usertbls.ToList());
        }

        // GET: usertbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usertbl usertbl = db.usertbls.Find(id);
            if (usertbl == null)
            {
                return HttpNotFound();
            }
            return View(usertbl);
        }

        // GET: usertbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usertbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,usertname,Password")] usertbl usertbl)
        {
            if (ModelState.IsValid)
            {
                db.usertbls.Add(usertbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usertbl);
        }

        // GET: usertbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usertbl usertbl = db.usertbls.Find(id);
            if (usertbl == null)
            {
                return HttpNotFound();
            }
            return View(usertbl);
        }

        // POST: usertbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,usertname,Password")] usertbl usertbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usertbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usertbl);
        }

        // GET: usertbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usertbl usertbl = db.usertbls.Find(id);
            if (usertbl == null)
            {
                return HttpNotFound();
            }
            return View(usertbl);
        }

        // POST: usertbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usertbl usertbl = db.usertbls.Find(id);
            db.usertbls.Remove(usertbl);
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
