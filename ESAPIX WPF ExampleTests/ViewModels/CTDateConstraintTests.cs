using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESAPX_StarterUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Constraints;

namespace ESAPX_StarterUI.ViewModels.Tests
{
    [TestClass()]
    public class CTDateConstraintTests
    {
        [TestMethod()]
        public void CTDateLessThan60_ShouldPass()
        {
            // Arrange
            var testClass = new CTDateConstraint();
            var recentDate = DateTime.Now.AddDays(-30); // Date within the last 60 days

            // Act
            var result = testClass.ConstrainDateOnly(recentDate);

            // Assert
            Assert.AreEqual(ResultType.PASSED, result.ResultType);
        }

        [TestMethod()]
        public void CTDateMoreThan60_ShouldFail()
        {
            // Arrange
            var testClass = new CTDateConstraint();
            var oldDate = DateTime.Now.AddDays(-90); // Date more than 60 days ago

            // Act
            var result = testClass.ConstrainDateOnly(oldDate);

            // Assert
            Assert.AreEqual(ResultType.ACTION_LEVEL_3, result.ResultType);
        }
    }
}