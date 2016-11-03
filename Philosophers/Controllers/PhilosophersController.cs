using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Philosophers.Models;

namespace Philosophers.Controllers
{
    public class PhilosophersController : Controller
    {
        private PhilosopherDBContext db = new PhilosopherDBContext();

        public ActionResult Index(string AreaID, string searchString)
        {
            PopulateAreaList();

            var philosophers = from p in db.Philosophers.Include("Area")
                               select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                philosophers = philosophers.Where(p => p.LastName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(AreaID))
            {
                philosophers = philosophers.Where(p => p.Area.Name == AreaID);
            }

            return View(philosophers);
        }

        // GET: Philosophers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosophers.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            return View(philosopher);
        }

        // GET: Philosophers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Philosophers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhilosopherID,FirstName,LastName,DateOfBirth,DateOfDeath,Area,Nationality,Description")] Philosopher philosopher)
        {
            if (ModelState.IsValid)
            {
                db.Philosophers.Add(philosopher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(philosopher);
        }

        // GET: Philosophers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosophers.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            return View(philosopher);
        }

        // POST: Philosophers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhilosopherID,FirstName,LastName,DateOfBirth,DateOfDeath,Area,Nationality,Description")] Philosopher philosopher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(philosopher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(philosopher);
        }

        // GET: Philosophers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosophers.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            return View(philosopher);
        }

        // POST: Philosophers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Philosopher philosopher = db.Philosophers.Find(id);
            db.Philosophers.Remove(philosopher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateAreaList(object selectedArea = null)
        {
            var areaQuery = from a in db.Areas
                            orderby a.Name
                            select a;

            ViewBag.AreaID = new SelectList(areaQuery, "AreaId", "Name", selectedArea);
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
