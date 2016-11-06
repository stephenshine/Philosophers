using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Philosophers.Models;
using System.Net;

namespace Philosophers.Controllers
{
    public class AreasController : Controller
    {
        PhilosopherDBContext db = new PhilosopherDBContext();

        public ActionResult Index()
        {
            PopulateAreaList();
            var areas = from a in db.Areas
                        .Include("Philosophers").Include("Books")
                        orderby a.Name
                        select a;

            return View(areas);
        }

        public ActionResult Details(string areaName)
        {
            if (areaName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var area = (from a in db.Areas
                       .Include("Philosophers").Include("Books")
                       where a.Name.Equals(areaName)
                       select a).SingleOrDefault();

            if (area == null)
            {
                return HttpNotFound();
            }

            return View(area);
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
            ViewBag.areaName = new SelectList(areaQuery, "Name", "Name", selectedArea);
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