using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Sensei.App_Start;
using Sensei.Seeder;

namespace Sensei
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            var kernel = NinjectWebCommon.Kernel;

            var roleSeeder = kernel.Get<ISeeder>("rolesSeeder");
            roleSeeder.Seed();

            var adminSeeder = kernel.Get<ISeeder>("adminSeeder");
            adminSeeder.Seed();
        }
    }
}
