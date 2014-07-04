// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Story.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The story.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The story.
    /// </summary>
    public class Story
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="Story"/> class.</summary>
        public Story()
        {
            this.Steps = new List<Step>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>Gets or sets the genre.</summary>
        [Required]
        public virtual Genre Genre { get; set; }

        /// <summary>
        ///     Gets the steps.
        /// </summary>
        public virtual IList<Step> Steps { get; private set; }

        #endregion
    }
}