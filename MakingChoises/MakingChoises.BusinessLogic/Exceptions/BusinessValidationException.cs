// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessValidationException.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MakingChoises.BusinessLogic.Exceptions
{
    using System;

    using Microsoft.Practices.EnterpriseLibrary.Validation;

    /// <summary>The business validation exception.</summary>
    public class BusinessValidationException : Exception
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="BusinessValidationException"/> class.</summary>
        /// <param name="results">The results.</param>
        public BusinessValidationException(ValidationResults results)
        {
            this.Results = results;
        }

        /// <summary>Initializes a new instance of the <see cref="BusinessValidationException"/> class.</summary>
        /// <param name="results">The results.</param>
        /// <param name="message">The message.</param>
        public BusinessValidationException(ValidationResults results, string message)
            : base(message)
        {
            this.Results = results;
        }

        /// <summary>Initializes a new instance of the <see cref="BusinessValidationException"/> class.</summary>
        /// <param name="results">The results.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public BusinessValidationException(ValidationResults results, string message, Exception innerException)
            : base(message, innerException)
        {
            this.Results = results;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the results.</summary>
        public ValidationResults Results { get; set; }

        #endregion
    }
}