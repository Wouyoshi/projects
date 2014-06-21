// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Problem.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The problem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.Model
{
    using System.Collections.Generic;

    /// <summary>
    ///     The problem.
    /// </summary>
    public class Problem
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the options.
        /// </summary>
        public virtual IList<Option> Options { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public string Text { get; set; }

        #endregion
    }
}