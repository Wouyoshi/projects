// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoryReadRepository.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using MakingChoises.ReadModel;

    /// <summary>The story read repository.</summary>
    public class StoryReadRepository : IStoryReadRepository
    {
        #region Fields

        /// <summary>The database context.</summary>
        private readonly DatabaseContext databaseContext;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="StoryReadRepository" /> class.</summary>
        public StoryReadRepository()
        {
            this.databaseContext = new DatabaseContext();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The get stories.</summary>
        /// <returns>The <see cref="IEnumerable{StoriesByGenre}"/>.</returns>
        public IEnumerable<StoriesByGenre> GetStories()
        {
            IQueryable<StoriesByGenre> stories = from genre in this.databaseContext.Genres
                                                 select
                                                     new StoriesByGenre
                                                         {
                                                             Genre = genre.Name, 
                                                             Stories =
                                                                 from story in this.databaseContext.Stories
                                                                 select story.Name
                                                         };
            return stories;
        }

        /// <summary>The get story by name.</summary>
        /// <param name="storyName">The story name.</param>
        /// <returns>The <see cref="Story"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when an argument is null.</exception>
        public Story GetStoryByName(string storyName)
        {
            if (string.IsNullOrWhiteSpace(storyName))
            {
                throw new ArgumentNullException("storyName");
            }

            Model.Story storyModel = this.databaseContext.Stories.FirstOrDefault(st => st.Name == storyName);
            var story = Mapper.Map<Story>(storyModel);
            return story;
        }

        #endregion
    }
}