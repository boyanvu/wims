using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Factories;
using Wims.Models.Common;
using Wims.Models.Contracts;

namespace Wims.Tests.Factory.Tests
{
    [TestClass]
    public class Create_Feedback_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeFeedback()
        {
            // Arrange
            var factory = new WimsFactory();

            // Act
            var feedback = factory.CreateFeedback("NewCreatedFeedback", "NewCreatedFeedDescr", 5);

            // Assert
            Assert.IsInstanceOfType(feedback, typeof(IFeedback));
        }
    }
}
