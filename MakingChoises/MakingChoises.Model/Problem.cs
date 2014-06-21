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
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="Problem" /> class.</summary>
        public Problem()
        {
            this.Options = new List<Option>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
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