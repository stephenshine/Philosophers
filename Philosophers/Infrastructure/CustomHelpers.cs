using Philosophers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Philosophers.Infrastructure
{
    public static class CustomHelpers
    {

        public static MvcHtmlString PhilosopherData(this HtmlHelper html, Philosopher philosopher)
        {


            return new MvcHtmlString();
        }
    }
}