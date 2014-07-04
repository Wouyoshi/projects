// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Route.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The route.
    /// </summary>
    public class Route
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="Route" /> class.</summary>
        public Route()
        {
            this.Conditions = new List<Condition>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the conditions.
        /// </summary>
        public virtual IList<Condition> Conditions { get; private set; }


        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the next problem.
        /// </summary>
        [Required]
        public virtual Problem NextProblem { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        public int Number { get; set; }

        #endregion
    }
}