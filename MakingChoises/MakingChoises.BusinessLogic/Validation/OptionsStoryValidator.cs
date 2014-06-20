﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionsStoryValidator.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The options story validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MakingChoises.DataAccess;
    using MakingChoises.Model;

    using Microsoft.Practices.EnterpriseLibrary.Validation;

    /// <summary>
    ///     The options validator.
    /// </summary>
    public class OptionsStoryValidator : Validator<IList<int>>
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

        /// <summary>The story.</summary>
        private readonly Story story;
        
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="OptionsStoryValidator"/> class.</summary>
        /// <param name="story">The story.</param>
        public OptionsStoryValidator(Story story)
            : base(UsedMessageTemplate, UsedTag)
        {
            if (story == null)
            {
                throw new ArgumentNullException("story");
            }

            this.story = story;
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

            var firstStep = this.story.Steps.FirstOrDefault(st => st.Number == 1);
            if (firstStep == null)
            {
                validationResults.AddResult(new ValidationResult("Story doesn't contain a first step.", currentTarget, key, "STOR001", this));
                return;
            }

            var firstStepProblems = firstStep.Problems;
            
            if (firstStepProblems.Count != 1)
            {
                validationResults.AddResult(new ValidationResult(string.Format("First step of the story contains the wrong amount of problems, {0} instead of 1.", firstStepProblems.Count), currentTarget, key, "STOR002", this));
                return;
            }

            var firstProblem = firstStepProblems.First();
            var firstProblemOptions = firstProblem.Options;
            if (firstProblemOptions.Count < 1)
            {
                validationResults.AddResult(new ValidationResult("First problem should have at least 1 option.", currentTarget, key, "STOR003", this));
                return;
            }

            var firstOptionChosen = firstProblem.Options.FirstOrDefault(fp => fp.Number == objectToValidate[0]);
            if (firstOptionChosen == null)
            {
                validationResults.AddResult(new ValidationResult(string.Format("{0} is not a valid option.", objectToValidate[0]), currentTarget, key, "STOR004", this));
                return;
            }
            
            // Todo: Check for conditions here.
            var routeFollowed = firstOptionChosen.Routes.FirstOrDefault();
            if (routeFollowed == null)
            {
                validationResults.AddResult(new ValidationResult("There was no valid route.", currentTarget, key, "STOR005", this));
                return;
            }
        }

        #endregion
    }
}