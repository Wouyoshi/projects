// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindsorDependencyScope.cs" company="Wouyoshi BV">
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

    /// <summary>The windsor dependency scope.</summary>
    public class WindsorDependencyScope : IDependencyScope
    {
        #region Fields

        /// <summary>The container.</summary>
        private readonly IWindsorContainer container;

        /// <summary>The scope.</summary>
        private readonly IDisposable scope;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="WindsorDependencyScope"/> class.</summary>
        /// <param name="container">The container.</param>
        public WindsorDependencyScope(IWindsorContainer container)
        {
            this.container = container;
            this.scope = container.BeginScope();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            this.scope.Dispose();
        }

        /// <summary>The get service.</summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetService(Type serviceType)
        {
            if (this.container.Kernel.HasComponent(serviceType))
            {
                return this.container.Resolve(serviceType);
            }

            return null;
        }

        /// <summary>The get services.</summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The <see cref="IEnumerable{object}"/>.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.ResolveAll(serviceType).Cast<object>();
        }

        #endregion
    }
}