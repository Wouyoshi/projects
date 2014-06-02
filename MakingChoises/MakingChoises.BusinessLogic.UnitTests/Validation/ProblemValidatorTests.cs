// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProblemValidatorTests.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The problem validator tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic.UnitTests.Validation
{
    using MakingChoises.BusinessLogic.Validation;
    using MakingChoises.Model;

    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The problem validator tests.</summary>
    [TestClass]
    public class ProblemValidatorTests
    {
        #region Public Methods and Operators

        /// <summary>The problem validator test.</summary>
        [TestMethod]
        public void ProblemValidatorTest()
        {
            var problemValidator = new ProblemValidator();
            var problem = new Problem();
            ValidationResults result = problemValidator.Validate(problem);
        }

        #endregion
    }
}