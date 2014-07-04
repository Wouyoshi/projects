// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStoryReadRepository.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.DataAccess
{
    using System.Collections.Generic;

    using MakingChoises.ReadModel;

    /// <summary>The StoryReadRepository interface.</summary>
    public interface IStoryReadRepository
    {
        #region Public Methods and Operators

        /// <summary>The get stories.</summary>
        /// <returns>The <see cref="IEnumerable{StoriesByGenre}" />.</returns>
        IEnumerable<StoriesByGenre> GetStories();

        /// <summary>The get story by name.</summary>
        /// <param name="storyName">The story name.</param>
        /// <returns>The <see cref="Story"/>.</returns>
        Story GetStoryByName(string storyName);

        #endregion
    }
}