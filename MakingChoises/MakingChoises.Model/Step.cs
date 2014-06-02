// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The step.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.Model
{
    using System.Collections.Generic;

    /// <summary>
    ///     The step.
    /// </summary>
    public class Step
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the problems.
        /// </summary>
        public IList<Problem> Problems { get; set; }

        #endregion
    }
}