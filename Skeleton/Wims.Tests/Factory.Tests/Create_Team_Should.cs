using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Factories;
using Wims.Models.Contracts;

namespace Wims.Tests.Factory.Tests
{
    [TestClass]
    public class Create_Team_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeTeam()
        {
            // Arrange
            var factory = new WimsFactory();

            // Act
            var team = factory.CreateTeam("Mandalorians");

            // Assert
            Assert.IsInstanceOfType(team, typeof(ITeam));
        }
    }
}
