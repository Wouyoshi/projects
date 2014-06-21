// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoryRetriever.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.DataAccess
{
    using System;
    using System.Linq;

    using MakingChoises.Model;

    /// <summary>The story retriever.</summary>
    public class StoryRetriever : IStoryRetriever
    {
        #region Fields

        /// <summary>The database context.</summary>
        private readonly DatabaseContext databaseContext;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="StoryRetriever"/> class.</summary>
        public StoryRetriever()
        {
            this.databaseContext = new DatabaseContext();
        }

        #endregion

        #region Methods

        /// <summary>The get story by name.</summary>
        /// <param name="storyName">The story name.</param>
        /// <returns>The <see cref="Story"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when storyName is null.</exception>
        public Story GetStoryByName(string storyName)
        {
            if (string.IsNullOrWhiteSpace(storyName))
            {
                throw new ArgumentNullException("storyName");
            }

            var stories = this.databaseContext.Stories.Where(story => story.Name == storyName);
            return stories.FirstOrDefault();
        }

        #endregion
    }
}