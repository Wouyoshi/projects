// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoryInstaller.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.WebApi.DIInstallers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using MakingChoises.BusinessLogic;
    using MakingChoises.DataAccess;

    /// <summary>The windsor installer.</summary>
    public class StoryInstaller : IWindsorInstaller
    {
        #region Public Methods and Operators

        /// <summary>The install.</summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IStoryRetriever>().ImplementedBy<StoryRetriever>().LifestyleTransient());
            container.Register(Component.For<IStoryManager>().ImplementedBy<StoryManager>().LifestyleTransient());
        }

        #endregion
    }
}