// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Route.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The route.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.Model
{
    using System.Collections.Generic;

    /// <summary>
    ///     The route.
    /// </summary>
    public class Route
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the conditions.
        /// </summary>
        public virtual IList<Condition> Conditions { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the next problem.
        /// </summary>
        public Problem NextProblem { get; set; }

        #endregion
    }
}