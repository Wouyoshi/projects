// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoryManager.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using MakingChoises.BusinessLogic.Exceptions;
    using MakingChoises.BusinessLogic.Validation;
    using MakingChoises.DataAccess;
    using MakingChoises.Model;

    using Microsoft.Practices.EnterpriseLibrary.Validation;

    using Option = MakingChoises.Model.Option;
    using Problem = MakingChoises.ReadModel.Problem;
    using Story = MakingChoises.ReadModel.Story;

    /// <summary>The story manager.</summary>
    public class StoryManager : IStoryManager
    {
        #region Fields

        /// <summary>The story retriever.</summary>
        private readonly IStoryRetriever storyRetriever;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="StoryManager"/> class.</summary>
        /// <param name="storyRetriever">The story retriever.</param>
        public StoryManager(IStoryRetriever storyRetriever)
        {
            if (storyRetriever == null)
            {
                throw new ArgumentNullException("storyRetriever");
            }

            this.storyRetriever = storyRetriever;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The get next problem.</summary>
        /// <param name="storyName">The story name.</param>
        /// <param name="options">The options.</param>
        /// <returns>The <see cref="ReadModel.Problem"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="BusinessValidationException">Thrown when arguments do not pass validation.</exception>
        /// <exception cref="ArgumentException">Thrown when the story doesn't exist.</exception>
        public Problem GetNextProblem(string storyName, IList<int> options)
        {
            if (string.IsNullOrWhiteSpace(storyName))
            {
                throw new ArgumentNullException("storyName");
            }

            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            // Check basic options validity.
            var optionsValidator = new OptionsValidator();
            ValidationResults optionsValidationResults = optionsValidator.Validate(options);
            if (!optionsValidationResults.IsValid)
            {
                throw new BusinessValidationException(optionsValidationResults);
            }

            // Get the story.
            Model.Story story = this.storyRetriever.GetStoryByName(storyName);

            if (story == null)
            {
                throw new ArgumentException(string.Format("The story {0} doesn't exist.", storyName));
            }

            var optionsStoryValidator = new OptionsStoryValidator(story);
            ValidationResults optionsStoryvalidationResults = optionsStoryValidator.Validate(options);
            if (!optionsStoryvalidationResults.IsValid)
            {
                throw new BusinessValidationException(optionsStoryvalidationResults);
            }

            Model.Problem firstProblem = story.Steps.First(step => step.Number == 1).Problems.First();
            Problem problem = this.GetProblem(firstProblem, options, 0);
            return problem;
        }

        /// <summary>The get story.</summary>
        /// <param name="storyName">The story name.</param>
        /// <returns>The <see cref="ReadModel.Story"/>.</returns>
        public Story GetStory(string storyName)
        {
            if (string.IsNullOrWhiteSpace(storyName))
            {
                throw new ArgumentNullException("storyName");
            }

            // Get the story.
            Model.Story storyModel = this.storyRetriever.GetStoryByName(storyName);

            if (storyModel == null)
            {
                throw new ArgumentException(string.Format("The story {0} doesn't exist.", storyName));
            }

            var story = Mapper.Map<Story>(storyModel);
            return story;
        }

        #endregion

        #region Methods

        /// <summary>The get problem.</summary>
        /// <param name="currentProblem">The current problem.</param>
        /// <param name="options">The options.</param>
        /// <param name="currentOption">The current option.</param>
        /// <returns>The <see cref="Problem"/>.</returns>
        private Problem GetProblem(Model.Problem currentProblem, IList<int> options, int currentOption)
        {
            Option option = currentProblem.Options.First(opt => opt.Number == options[currentOption]);

            // Todo: Check for conditions here.
            Route route = option.Routes.First();

            Model.Problem nextProblem = route.NextProblem;
            currentOption = currentOption + 1;
            if (currentOption >= options.Count)
            {
                var problem = Mapper.Map<Problem>(nextProblem);
                return problem;
            }

            return this.GetProblem(nextProblem, options, currentOption);
        }

        #endregion
    }
}