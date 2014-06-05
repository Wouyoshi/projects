// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseContext.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The database context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.DataAccess
{
    using System.Data.Entity;

    using MakingChoises.Model;

    /// <summary>The database context.</summary>
    public class DatabaseContext : DbContext
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="DatabaseContext" /> class.</summary>
        public DatabaseContext()
            : base("Connection")
        {
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the conditions.</summary>
        public DbSet<Condition> Conditions { get; set; }

        /// <summary>Gets or sets the options.</summary>
        public DbSet<Option> Options { get; set; }

        /// <summary>Gets or sets the problems.</summary>
        public DbSet<Problem> Problems { get; set; }

        /// <summary>Gets or sets the routes.</summary>
        public DbSet<Route> Routes { get; set; }

        /// <summary>Gets or sets the steps.</summary>
        public DbSet<Step> Steps { get; set; }

        /// <summary>Gets or sets the stories.</summary>
        public DbSet<Story> Stories { get; set; }

        #endregion
    }
}