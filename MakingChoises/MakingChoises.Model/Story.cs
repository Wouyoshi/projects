// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Story.cs" company="Wouyoshi BV">
//   W. Schutten
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
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the steps.
        /// </summary>
        public virtual IList<Step> Steps { get; set; }

        #endregion
    }
}