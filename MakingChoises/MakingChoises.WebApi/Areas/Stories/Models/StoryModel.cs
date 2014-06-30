// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoryModel.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.WebApi.Areas.Stories.Models
{
    using System.Collections.Generic;

    /// <summary>The story model.</summary>
    public class StoryModel
    {
        #region Public Properties

        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the options.</summary>
        public IDictionary<int, string> Options { get; set; }

        /// <summary>Gets or sets the previous options.</summary>
        public string PreviousOptions { get; set; }

        /// <summary>Gets or sets the text.</summary>
        public string Text { get; set; }

        #endregion
    }
}