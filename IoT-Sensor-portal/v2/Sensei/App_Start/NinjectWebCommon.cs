using Microsoft.AspNet.Identity.Owin;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Sensei.Controllers;
using Sensei.Database;
using Sensei.Database.Contracts;
using Sensei.Database.Seeder;
using Sensei.Services;
using Sensei.Services.Contracts;
using System;
using System.Net.Http;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Sensei.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Sensei.App_Start.NinjectWebCommon), "Stop")]

namespace Sensei.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static IKernel Kernel { get; private set; }

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(Kernel);
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<HttpClient>().To<HttpClient>();

            kernel.Bind<IApplicationDbContext>().To<ApplicationDbContext>();
            kernel.Bind<ApplicationUserManager>()
                .ToMethod(_=> HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());
            kernel.Bind<ApplicationSignInManager>()
                .ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());

            kernel.Bind<ISeeder>().To<RolesSeeder>().Named("rolesSeeder");
            kernel.Bind<ISeeder>().To<AdminSeeder>().Named("adminSeeder");

            kernel.Bind<IDBService>().To<DBService>();

            kernel.Bind<IAPIService>().To<APIService>();

            kernel.Bind<SensorController>().To<SensorController>();
        }
    }
}
