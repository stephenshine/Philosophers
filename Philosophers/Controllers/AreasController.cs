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

        public ActionResult Index()
        {
            return View();
        }
    }
}