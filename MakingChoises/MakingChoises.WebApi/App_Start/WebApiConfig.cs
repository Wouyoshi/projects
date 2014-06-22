// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.WebApi
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    using Castle.Windsor;

    using MakingChoises.WebApi.DIPlumbing;

    using Microsoft.Owin.Security.OAuth;

    /// <summary>The web API config.</summary>
    public static class WebApiConfig
    {
        #region Public Methods and Operators

        /// <summary>The map routes.</summary>
        /// <param name="config">The config.</param>
        public static void MapRoutes(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }

        /// <summary>The register.</summary>
        /// <param name="config">The config.</param>
        /// <param name="container">The container.</param>
        public static void Register(HttpConfiguration config, IWindsorContainer container)
        {
            MapRoutes(config);
            RegisterControllerActivator(container);
        }

        #endregion

        #region Methods

        /// <summary>The register controller activator.</summary>
        /// <param name="container">The container.</param>
        private static void RegisterControllerActivator(IWindsorContainer container)
        {
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator), 
                new WindsorCompositionRoot(container));
        }

        #endregion
    }
}