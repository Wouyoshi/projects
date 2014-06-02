// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoryValidatorTests.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The story validator tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic.UnitTests.Validation
{
    using MakingChoises.BusinessLogic.Validation;
    using MakingChoises.Model;

    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The story validator tests.</summary>
    [TestClass]
    public class StoryValidatorTests
    {
        #region Public Methods and Operators

        /// <summary>The story validator test.</summary>
        [TestMethod]
        public void StoryValidatorTest()
        {
            var storyValidator = new StoryValidator();
            var story = new Story();
            ValidationResults result = storyValidator.Validate(story);
        }

        #endregion
    }
}