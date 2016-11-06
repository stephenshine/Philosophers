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
                        .Include("Philosophers")
                        orderby a.Name
                        select a;

            return View(areas);
        }

        public ActionResult Details(int? AreaId)
        {
            if (AreaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var area = (from a in db.Areas.Include("Philosophers")
                       where a.AreaId == AreaId
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