﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using AspDotNetCourseApp.App_Start;
using AspDotNetCourseApp.Helpers;
using AspDotNetCourseApp.Models;

namespace AspDotNetCourseApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // Register the routes as configured in RouteConfig.cs:
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Seed User Roles if undefined:
            var identitySeed = new IdentitySeed();
            identitySeed.CreateRolesAsync(new ApplicationDbContext()).Wait();          

        }
    }
}
