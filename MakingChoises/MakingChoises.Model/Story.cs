// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Story.cs" company="">
//   
// </copyright>
// <summary>
//   The story.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.Model
{
    using System.Collections.Generic;

    /// <summary>
    ///     The story.
    /// </summary>
    public class Story
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the steps.
        /// </summary>
        public IList<Step> Steps { get; set; }

        #endregion
    }
}