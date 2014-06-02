// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConditionValidatorTests.cs" company="">
//   
// </copyright>
// <summary>
//   The condition validator tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic.UnitTests.Validation
{
    using MakingChoises.BusinessLogic.Validation;
    using MakingChoises.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     The condition validator tests.
    /// </summary>
    [TestClass]
    public class ConditionValidatorTests
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The condition validator test.
        /// </summary>
        [TestMethod]
        public void ConditionValidatorTest()
        {
            var conditionValidator = new ConditionValidator();
            var condition = new Condition();
            conditionValidator.Validate(condition);
        }

        #endregion
    }
}