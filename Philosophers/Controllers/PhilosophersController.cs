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

        public ActionResult Index(string searchString)
        {
            var philosophers = from p in db.Philosophers
                               .Include("Area")
                               .Include("Nationality")
                               select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                philosophers = philosophers.Where(p => p.LastName.Contains(searchString));
            }

            return View(philosophers);
        }

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

        public ActionResult Create()
        {
            PopulateAreaList();
            PopulateNationalityList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhilosopherID,FirstName,LastName,DateOfBirth,DateOfDeath,AreaID,NationalityID,Description")] Philosopher philosopher)
        {
            if (ModelState.IsValid)
            {
                db.Philosophers.Add(philosopher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateAreaList(philosopher.AreaID);
            PopulateNationalityList(philosopher.NationalityID);
            return View(philosopher);
        }

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
            PopulateAreaList(philosopher.AreaID);
            PopulateNationalityList(philosopher.NationalityID);
            return View(philosopher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhilosopherID,FirstName,LastName,DateOfBirth,DateOfDeath,AreaID,NationalityID,Description")] Philosopher philosopher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(philosopher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(philosopher);
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Philosopher philosopher = db.Philosophers.Find(id);
            db.Philosophers.Remove(philosopher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // methods to populate dropdown lists with data from tables
        // takes one argument which is used to pre-select item in list.
        private void PopulateAreaList(object selectedArea = null)
        {

            // LINQ query to get all areas from table
            var areaQuery = from a in db.Areas
                            orderby a.Name
                            select a;

            // Query is run here - SelectList(collection, valueField, textField, selectedValue) 
            ViewBag.AreaID = new SelectList(areaQuery, "AreaId", "Name", selectedArea);
        }

        private void PopulateNationalityList(object selectedNationality = null)
        {
            var nationalityQuery = from n in db.Nationalities
                                   orderby n.Name
                                   select n;

            ViewBag.NationalityID = new SelectList(nationalityQuery, "NationalityID", "Name", selectedNationality);
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
