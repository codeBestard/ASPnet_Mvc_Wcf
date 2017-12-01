using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AdDataAggregation.App_Start;
using AdDataAggregation.Models;

namespace AdDataAggregation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start( )
        {
            IOC.Initialize();
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutomapperProfile>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes( RouteTable.Routes );
            BundleConfig.RegisterBundles( BundleTable.Bundles );
        }
    }
}
