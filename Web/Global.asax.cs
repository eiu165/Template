﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;

namespace Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            GlobalConfig.CustomizeConfig(GlobalConfiguration.Configuration);

            ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
            //var config = GlobalConfiguration.Configuration;

            //// Replace the default JsonFormatter with our custom one
            //var index = config.Formatters.IndexOf(config.Formatters.JsonFormatter);
            //config.Formatters[index] = new JsonCamelCaseFormatter();


        }
    }
}