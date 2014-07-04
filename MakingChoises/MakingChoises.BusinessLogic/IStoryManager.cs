// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStoryManager.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.BusinessLogic
{
    using System.Collections.Generic;

    using MakingChoises.ReadModel;

    /// <summary>The StoryManager interface.</summary>
    public interface IStoryManager
    {
        #region Public Methods and Operators

        /// <summary>The get next problem.</summary>
        /// <param name="storyName">The story name.</param>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="Problem"/>.</returns>
        Problem GetNextProblem(string storyName, IList<int> options);

        /// <summary>The get story.</summary>
        /// <param name="storyName">The story name.</param>
        /// <returns>The <see cref="Story"/>.</returns>
        Story GetStory(string storyName);

        /// <summary>The get story names.</summary>
        /// <returns>The <see cref="IEnumerable{StoriesByGenre}"/>.</returns>
        IEnumerable<StoriesByGenre> GetStories();

        #endregion
    }
}