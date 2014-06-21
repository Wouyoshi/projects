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
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The step.
    /// </summary>
    public class Step
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="Step"/> class.</summary>
        public Step()
        {
            this.Problems = new List<Problem>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the next step.
        /// </summary>
        public virtual Step NextStep { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the problems.
        /// </summary>
        public virtual IList<Problem> Problems { get; private set; }

        #endregion
    }
}