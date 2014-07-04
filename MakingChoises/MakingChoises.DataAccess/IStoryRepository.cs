// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStoryRepository.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.DataAccess
{
    using System.Collections.Generic;

    using MakingChoises.Model;

    /// <summary>The StoryRepository interface.</summary>
    public interface IStoryRepository
    {
        #region Public Methods and Operators

        /// <summary>The get story by name.</summary>
        /// <param name="storyName">The story name.</param>
        /// <returns>The <see cref="Story"/>.</returns>
        Story GetStoryByName(string storyName);
        
        #endregion
    }
}