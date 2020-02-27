using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Factories;
using Wims.Models.Contracts;

namespace Wims.Tests.Factory.Tests
{
    [TestClass]
    public class Create_Member_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeMember()
        {
            // Arrange
            var factory = new WimsFactory();

            // Act
            var member = factory.CreateMember("Boyan");

            // Assert
            Assert.IsInstanceOfType(member, typeof(IMember));
        }
    }
}
