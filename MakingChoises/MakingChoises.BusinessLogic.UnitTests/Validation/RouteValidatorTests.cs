// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteValidatorTests.cs" company="Wouyoshi BV">
//   W. Schutten
// </copyright>
// <summary>
//   The route validator tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MakingChoises.BusinessLogic.UnitTests.Validation
{
    using MakingChoises.BusinessLogic.Validation;
    using MakingChoises.Model;

    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The route validator tests.</summary>
    [TestClass]
    public class RouteValidatorTests
    {
        #region Public Methods and Operators

        /// <summary>The route validator test.</summary>
        [TestMethod]
        public void RouteValidatorTest()
        {
            var routeValidator = new RouteValidator();
            var route = new Route();
            ValidationResults result = routeValidator.Validate(route);
        }

        #endregion
    }
}