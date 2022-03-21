using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace WebApplication5.Controllers
{
    public class DronsController : Controller
    {
        private DataContex db = new DataContex();

        // GET: Drons
        public ActionResult Index()
        {
            return View(db.dron.ToList());
        }

        // GET: Drons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dron dron = db.dron.Find(id);
            if (dron == null)
            {
                return HttpNotFound();
            }
            return View(dron);
        }

        // GET: Drons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Latitude,Longitude,Absolute")] Dron dron)
        {
            if (ModelState.IsValid)
            {
                db.dron.Add(dron);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dron);
        }

        // GET: Drons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dron dron = db.dron.Find(id);
            if (dron == null)
            {
                return HttpNotFound();
            }
            return View(dron);
        }

        // POST: Drons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Latitude,Longitude,Absolute")] Dron dron)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dron).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dron);
        }

        // GET: Drons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dron dron = db.dron.Find(id);
            if (dron == null)
            {
                return HttpNotFound();
            }
            return View(dron);
        }

        // POST: Drons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dron dron = db.dron.Find(id);
            db.dron.Remove(dron);
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
