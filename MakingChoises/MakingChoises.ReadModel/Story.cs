// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Story.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.ReadModel
{
    /// <summary>The story.</summary>
    public class Story
    {
        #region Public Properties

        /// <summary>Gets or sets the first problem.</summary>
        public Problem FirstProblem { get; set; }
        
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}