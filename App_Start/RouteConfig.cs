using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CloudBasedFingerIdentificationSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Department", "Department/{action}/{id}", new { Controller = "Department", Action = "Departments", id = UrlParameter.Optional }, new[] { "DepartmentController.Controllers" });
            routes.MapRoute("Designation", "Designation/{action}/{id}", new { Controller = "Designation", Action = "Designation", id = UrlParameter.Optional }, new[] { "DepartmentController.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
