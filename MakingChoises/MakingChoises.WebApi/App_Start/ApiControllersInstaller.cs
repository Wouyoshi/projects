// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiControllersInstaller.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.WebApi
{
    using System.Web.Http;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    /// <summary>The API controllers installer.</summary>
    public class ApiControllersInstaller : IWindsorInstaller
    {
        #region Public Methods and Operators

        /// <summary>The install.</summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestylePerWebRequest());
        }

        #endregion
    }
}