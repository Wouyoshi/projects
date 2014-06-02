﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoryValidator.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The story validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic.Validation
{
    using System;

    using MakingChoises.Model;

    using Microsoft.Practices.EnterpriseLibrary.Validation;

    /// <summary>
    ///     The story validator.
    /// </summary>
    public class StoryValidator : Validator<Story>
    {
        #region Constants

        /// <summary>
        ///     The used message template.
        /// </summary>
        private const string UsedMessageTemplate = "";

        /// <summary>
        ///     The used tag.
        /// </summary>
        private const string UsedTag = "";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="StoryValidator" /> class.
        /// </summary>
        public StoryValidator()
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
        /// <exception cref="NotImplementedException"></exception>
        protected override void DoValidate(
            Story objectToValidate, 
            object currentTarget, 
            string key, 
            ValidationResults validationResults)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}