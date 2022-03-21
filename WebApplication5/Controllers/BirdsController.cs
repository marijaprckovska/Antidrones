using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class BirdsController : Controller
    {
        private DataContex db = new DataContex();

        // GET: Birds
        public ActionResult Index()
        {
            return View(db.bird.ToList());
        }

        // GET: Birds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bird bird = db.bird.Find(id);
            if (bird == null)
            {
                return HttpNotFound();
            }
            return View(bird);
        }

        // GET: Birds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Birds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Latitude,Longitude,Absolute")] Bird bird)
        {
            if (ModelState.IsValid)
            {
                db.bird.Add(bird);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bird);
        }

        // GET: Birds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bird bird = db.bird.Find(id);
            if (bird == null)
            {
                return HttpNotFound();
            }
            return View(bird);
        }

        // POST: Birds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Latitude,Longitude,Absolute")] Bird bird)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bird).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bird);
        }

        // GET: Birds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bird bird = db.bird.Find(id);
            if (bird == null)
            {
                return HttpNotFound();
            }
            return View(bird);
        }

        // POST: Birds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bird bird = db.bird.Find(id);
            db.bird.Remove(bird);
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
