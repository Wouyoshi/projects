// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Option.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The option.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The option.
    /// </summary>
    public class Option
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="Option"/> class.</summary>
        public Option()
        {
            this.Routes = new List<Route>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the routes.
        /// </summary>
        public virtual IList<Route> Routes { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public string Text { get; set; }

        #endregion
    }
}