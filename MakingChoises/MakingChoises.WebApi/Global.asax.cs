// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.WebApi
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using MakingChoises.BusinessLogic;

    /// <summary>The web API application.</summary>
    public class WebApiApplication : HttpApplication
    {
        #region Static Fields

        /// <summary>The container.</summary>
        private static IWindsorContainer container;

        #endregion

        #region Public Methods and Operators

        /// <summary>The configure windsor.</summary>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureWindsor(HttpConfiguration configuration)
        {
            container = new WindsorContainer();
            container.Install(FromAssembly.This());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;
        }

        #endregion

        #region Methods

        /// <summary>The application_ end.</summary>
        protected void Application_End()
        {
            container.Dispose();
            this.Dispose();
        }

        /// <summary>The application_ start.</summary>
        protected void Application_Start()
        {
            ConfigureWindsor(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfiguration.Configure();
        }

        #endregion
    }
}