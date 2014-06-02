// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepValidatorTests.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The step validator tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic.UnitTests.Validation
{
    using MakingChoises.BusinessLogic.Validation;
    using MakingChoises.Model;

    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The step validator tests.</summary>
    [TestClass]
    public class StepValidatorTests
    {
        #region Public Methods and Operators

        /// <summary>The step validator test.</summary>
        [TestMethod]
        public void StepValidatorTest()
        {
            var stepValidator = new StepValidator();
            var step = new Step();
            ValidationResults result = stepValidator.Validate(step);
        }

        #endregion
    }
}