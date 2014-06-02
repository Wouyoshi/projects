// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionValidatorTests.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The option validator tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic.UnitTests.Validation
{
    using MakingChoises.BusinessLogic.Validation;
    using MakingChoises.Model;

    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The option validator tests.</summary>
    [TestClass]
    public class OptionValidatorTests
    {
        #region Public Methods and Operators

        /// <summary>The option validator test.</summary>
        [TestMethod]
        public void OptionValidatorTest()
        {
            var optionValidator = new OptionValidator();
            var option = new Option();
            ValidationResults result = optionValidator.Validate(option);
        }

        #endregion
    }
}