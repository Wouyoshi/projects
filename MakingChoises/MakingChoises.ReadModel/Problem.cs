// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Problem.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The problem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.ReadModel
{
    using System.Collections.Generic;

    /// <summary>The problem.</summary>
    public class Problem
    {
        #region Public Properties
        
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