namespace MakingChoises.BusinessLogic
{
    using System;
    using System.Collections.Generic;

    using MakingChoises.BusinessLogic.Exceptions;
    using MakingChoises.BusinessLogic.Validation;
    using MakingChoises.DataAccess;
    using MakingChoises.ReadModel;

    public class StoryManager
    {
        private readonly IStoryRetriever storyRetriever;

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

        public Story GetStory(string storyName)
        {
            
        }

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
            var validationResults = optionsValidator.Validate(options);
            if (!validationResults.IsValid)
            {
                throw new BusinessValidationException(validationResults);
            }

            // Get the story.
            var story = this.storyRetriever.GetStoryByName(storyName);

            if (story == null)
            {
                throw new ArgumentException(string.Format("The story {0} doesn't exist.", storyName));
            }


        }
    }
}
