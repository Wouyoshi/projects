// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Route.cs" company="">
//   
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
        public IList<Condition> Conditions { get; set; }

        /// <summary>
        ///     Gets or sets the next problem.
        /// </summary>
        public Problem NextProblem { get; set; }

        #endregion
    }
}