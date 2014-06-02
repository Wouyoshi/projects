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
        ///     Gets or sets the routes.
        /// </summary>
        public List<Route> Routes { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public string Text { get; set; }

        #endregion
    }
}