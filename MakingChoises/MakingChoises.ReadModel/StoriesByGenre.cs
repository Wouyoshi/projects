// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenreStories.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.ReadModel
{
    using System.Collections.Generic;

    /// <summary>The genre stories.</summary>
    public class StoriesByGenre
    {
        #region Public Properties

        /// <summary>Gets or sets the genre.</summary>
        public string Genre { get; set; }

        /// <summary>Gets or sets the stories.</summary>
        public IEnumerable<string> Stories { get; set; }

        #endregion
    }
}