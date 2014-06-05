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

    /// <summary>
    ///     The option.
    /// </summary>
    public class Option
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

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