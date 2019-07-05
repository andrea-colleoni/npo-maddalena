using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Giorno1Web1;

namespace Giorno1Web1.Controllers
{
    public class FatturesController : Controller
    {
        private Dati db = new Dati();

        // GET: Fattures
        public ActionResult Index()
        {
            return View(db.Fatture.ToList());
        }

        // GET: Fattures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatture fatture = db.Fatture.Find(id);
            if (fatture == null)
            {
                return HttpNotFound();
            }
            return View(fatture);
        }

        // GET: Fattures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fattures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,data,numero")] Fatture fatture)
        {
            if (ModelState.IsValid)
            {
                db.Fatture.Add(fatture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fatture);
        }

        // GET: Fattures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatture fatture = db.Fatture.Find(id);
            if (fatture == null)
            {
                return HttpNotFound();
            }
            return View(fatture);
        }

        // POST: Fattures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,data,numero")] Fatture fatture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fatture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fatture);
        }

        // GET: Fattures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fatture fatture = db.Fatture.Find(id);
            if (fatture == null)
            {
                return HttpNotFound();
            }
            return View(fatture);
        }

        // POST: Fattures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fatture fatture = db.Fatture.Find(id);
            db.Fatture.Remove(fatture);
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
