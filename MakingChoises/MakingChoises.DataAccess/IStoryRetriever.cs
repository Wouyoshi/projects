// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStoryRetriever.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.DataAccess
{
    using MakingChoises.Model;

    /// <summary>The StoryRetriever interface.</summary>
    public interface IStoryRetriever
    {
        #region Public Methods and Operators

        /// <summary>The get story by name.</summary>
        /// <param name="storyName">The story name.</param>
        /// <returns>The <see cref="Story"/>.</returns>
        Story GetStoryByName(string storyName);

        #endregion
    }
}