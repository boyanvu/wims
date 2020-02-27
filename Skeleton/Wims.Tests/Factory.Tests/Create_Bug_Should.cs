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
    public class Create_Bug_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeBug()
        {
            // Arrange
            var factory = new WimsFactory();

            // Act
            var bug = factory.CreateBug("NewCreatedBug", "NewCreateBugDescription", Priority.High, Severity.Minor);

            // Assert
            Assert.IsInstanceOfType(bug, typeof(IBug));
        }
    }
}
