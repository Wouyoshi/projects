﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConditionValidatorTests.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The condition validator tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic.UnitTests.Validation
{
    using MakingChoises.BusinessLogic.Validation;
    using MakingChoises.Model;

    using Microsoft.Practices.EnterpriseLibrary.Validation;
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
            ValidationResults result = conditionValidator.Validate(condition);
        }

        #endregion
    }
}