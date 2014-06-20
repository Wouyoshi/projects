// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionsValidator.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The options validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic.Validation
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Practices.EnterpriseLibrary.Validation;

    /// <summary>
    ///     The options validator.
    /// </summary>
    public class OptionsValidator : Validator<IList<int>>
    {

        #region Constants

        /// <summary>
        ///     The used message template.
        /// </summary>
        private const string UsedMessageTemplate = null;

        /// <summary>
        ///     The used tag.
        /// </summary>
        private const string UsedTag = null;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="OptionsValidator"/> class.</summary>
        public OptionsValidator()
            : base(UsedMessageTemplate, UsedTag)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the default message template.
        /// </summary>
        protected override string DefaultMessageTemplate
        {
            get
            {
                return "Validation failed.";
            }
        }

        #endregion

        #region Methods

        /// <summary>The do validate.</summary>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The current target.</param>
        /// <param name="key">The key.</param>
        /// <param name="validationResults">The validation results.</param>
        protected override void DoValidate(
            IList<int> objectToValidate, 
            object currentTarget, 
            string key, 
            ValidationResults validationResults)
        {
            if (objectToValidate == null)
            {
                validationResults.AddResult(new ValidationResult("Options may not be null.", currentTarget, key, "OPTS001", this));
                return;
            }

            if (objectToValidate.Count < 1)
            {
                validationResults.AddResult(new ValidationResult("There should at least be one chosen option.", currentTarget, key, "OPTS002", this));
                return;
            }

            if (objectToValidate.Any(option => option < 0))
            {
                validationResults.AddResult(new ValidationResult("Options can not be smaller than 0.", currentTarget, key, "OPTS003", this));
            }
        }

        #endregion
    }
}