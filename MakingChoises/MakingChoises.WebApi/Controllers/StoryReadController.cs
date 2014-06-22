// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoryReadController.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.WebApi.Controllers
{
    using System;
    using System.Web.Http;

    using MakingChoises.BusinessLogic;
    using MakingChoises.ReadModel;

    /// <summary>The story read controller.</summary>
    [RoutePrefix("api/story")]
    public class StoryReadController : ApiController
    {
        #region Fields

        /// <summary>The story manager.</summary>
        private readonly IStoryManager storyManager;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="StoryReadController"/> class.</summary>
        /// <param name="storyManager">The story manager.</param>
        public StoryReadController(IStoryManager storyManager)
        {
            this.storyManager = storyManager;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The get next problem.</summary>
        /// <param name="storyName">The story name.</param>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="Problem"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when storyName is null or options is null.</exception>
        [Route("{storyName}/{options}")]
        public Problem GetNextProblem(string storyName, [FromUri] int[] options)
        {
            if (storyName == null)
            {
                throw new ArgumentNullException("storyName");
            }

            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            Problem problem = this.storyManager.GetNextProblem(storyName, options);
            return problem;
        }

        /// <summary>The get story.</summary>
        /// <param name="storyName">The story name.</param>
        /// <returns>The <see cref="Story"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when story name is null.</exception>
        [Route("{storyName}")]
        public Story GetStory(string storyName)
        {
            if (storyName == null)
            {
                throw new ArgumentNullException("storyName");
            }

            Story story = this.storyManager.GetStory(storyName);
            return story;
        }

        #endregion
    }
}