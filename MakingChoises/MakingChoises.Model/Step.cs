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
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the problems.
        /// </summary>
        public virtual IList<Problem> Problems { get; set; }

        /// <summary>
        /// Gets or sets the next step.
        /// </summary>
        public Step NextStep { get; set; }

        #endregion
    }
}