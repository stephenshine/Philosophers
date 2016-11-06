using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Philosophers.Models;

namespace Philosophers.Controllers
{
    public class AreasController : Controller
    {
        PhilosopherDBContext db = new PhilosopherDBContext();

        public ActionResult Index(string areaName)
        {
            var areas = from a in db.Areas
                        .Include("Philosophers")
                        select a;

            if (!String.IsNullOrEmpty(areaName))
            {
                areas = areas.Where(a => a.Name == areaName);
            }

            return View(areas);
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