using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Factories;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Tests.Factory.Tests
{
    [TestClass]
    public class Create_Comment_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeComment()
        {
            // Arrange
            var factory = new WimsFactory();

            // Act
            var comment = factory.CreateComment("Boian", "Boian first comment");

            // Assert
            Assert.IsInstanceOfType(comment, typeof(IComment));
        }
    }
}
