using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspDotNetCourseApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //----------------------------------------------------------------------------------
            // MVC<5 way of defining custom routes. should use MVC attribute Routes instead
            // in MVC 5 and up (see above and i
            //----------------------------------------------------------------------------------
            //routes.MapRoute(
            //    name: "MoviesByReleaseDate",
            //    url: "movies/released/{year}/{month}",
            //    defaults: new { controller = "Movies", action = "ByReleaseDate"},
            //    constraints: new {year = @"2015|2016", month = @"\d{2}"}
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                // defaults:
                //  controller - if the url doesn't match the above pattern - HomeController will be called.
                //  action - if the action is missing - the Controller.Index() will be called.
                //  id  - is optional since not every page is indexed (for example, specific movies have ids but not the general movies page).
                //         if it exist, it will be handled by Controller.Index(id);
                //         Note: this parameters defines the automatic mapping of the route to the paramater that will be passed to the 
                //               controller's action method.
            );
        }
    }
}
