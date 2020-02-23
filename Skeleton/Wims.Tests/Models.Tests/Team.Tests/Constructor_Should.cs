using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wims.Models;

namespace Wims.Tests.Models.Tests
{
    [TestClass]
    public class Team_Constructor_Should
    {
        [TestMethod]
        public void SetCorrectTeamName()
        {
            //Arrange
            var teamName = "Mandalorians";

            //Act
            var team = new Team(teamName);

            //Assert
            Assert.AreEqual(teamName, team.Name);
        }


        [TestMethod]
        public void ThrowArgument_NullTeamName()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Team(null));
        }


    }
}
