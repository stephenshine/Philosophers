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
            var areas = from a in db.Areas
                        .Include("Philosophers")
                        orderby a.Name
                        select a;

            return View(areas);
        }

        public ActionResult Details(int? areaName)
        {
            if (areaName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var area = (from a in db.Areas.Include("Philosophers")
                       where a.AreaId == areaName
                       select a).SingleOrDefault();

            if (area == null)
            {
                return HttpNotFound();
            }

            return View(area);
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