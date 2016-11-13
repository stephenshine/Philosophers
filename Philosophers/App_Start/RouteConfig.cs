using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Philosophers
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Areas",
                url: "Areas/Details/{areaName}",
                defaults: new { controller = "Areas", action = "Details", areaName = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{lastName}",
                defaults: new { controller = "Philosophers", action = "Index", lastName = UrlParameter.Optional }
            );
        }
    }
}
