// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoryRepository.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MakingChoises.Model;

    /// <summary>The story retriever.</summary>
    public class StoryRepository : IStoryRepository
    {
        #region Fields

        /// <summary>The database context.</summary>
        private readonly DatabaseContext databaseContext;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="StoryRepository" /> class.</summary>
        public StoryRepository()
        {
            this.databaseContext = new DatabaseContext();
        }

        #endregion

        #region Public Methods and Operators
        
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

            Story story = this.databaseContext.Stories.FirstOrDefault(st => st.Name == storyName);
            return story;
        }

        #endregion
    }
}