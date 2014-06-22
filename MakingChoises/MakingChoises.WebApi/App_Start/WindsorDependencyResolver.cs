// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindsorDependencyResolver.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    using Castle.MicroKernel.Lifestyle;
    using Castle.Windsor;

    /// <summary>The windsor dependency resolver.</summary>
    public class WindsorDependencyResolver : IDependencyResolver
    {
        #region Fields

        /// <summary>The container.</summary>
        private readonly IWindsorContainer container;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="WindsorDependencyResolver"/> class.</summary>
        /// <param name="container">The container.</param>
        public WindsorDependencyResolver(IWindsorContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The begin scope.</summary>
        /// <returns>The <see cref="IDependencyScope" />.</returns>
        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(this.container);
        }

        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            this.container.Dispose();
        }

        /// <summary>The get service.</summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetService(Type serviceType)
        {
            return this.container.Kernel.HasComponent(serviceType) ? this.container.Resolve(serviceType) : null;
        }

        /// <summary>The get services.</summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The <see cref="IEnumerable{object}"/>.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (!this.container.Kernel.HasComponent(serviceType))
            {
                return new object[0];
            }

            return this.container.ResolveAll(serviceType).Cast<object>();
        }

        #endregion
    }
}