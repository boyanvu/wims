using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wims.Models;
using Wims.Models.Common;

namespace Wims.Tests.Models.Tests
{
    [TestClass]
    public class Bug_Constructor_Should
    {
        [TestMethod]
        public void SetCorrectBugProperties()
        {
            var bug = new Bug("NewCreatedBug", "NewCreateBugDescription", Priority.High, Severity.Minor);

            Assert.AreEqual("NewCreatedBug", bug.Title);
            Assert.AreEqual("NewCreateBugDescription", bug.Description);
            Assert.AreEqual(Priority.High, bug.Priority);
            Assert.AreEqual(Severity.Minor, bug.Severity);
        }

        [TestMethod]
        public void ReturnsCorrectTypeBug()
        {
            var bug = new Bug("NewCreatedBug", "NewCreateBugDescription", Priority.High, Severity.Minor);

            //Assert
            Assert.IsInstanceOfType(bug, typeof(Bug));
        }

        [TestMethod]
        public void ThrowWhenTheTitleIsNull()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() 
                => new Bug(null, "NewCreateBugDescription", Priority.High, Severity.Minor));
        }

        [TestMethod]
        public void ThrowWhenTheTitleIsOutOfRange()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => new Bug("Title", "NewCreateBugDescription", Priority.High, Severity.Minor));
        }

        [TestMethod]
        public void ThrowWhenTheDescriptionIsNull()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentNullException>(()
                => new Bug("NewCreatedBug", null, Priority.High, Severity.Minor));
        }

        [TestMethod]
        public void ThrowWhenTheDescriptionIsOutOfRange()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => new Bug("NewCreatedBug", "Descr", Priority.High, Severity.Minor));
        }



    }
}
