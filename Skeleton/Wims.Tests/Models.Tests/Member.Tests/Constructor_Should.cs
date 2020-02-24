using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wims.Models;

namespace Wims.Tests.Models.Tests

{
    [TestClass]
    public class Member_Constructor_Should
    {
        [TestMethod]
        public void MemberConstructorCreateValid()
        {
            // Arrange & Act
            Member testMember = new Member("Tosho");

            //Assert
            Assert.IsInstanceOfType(testMember, typeof(Member));
        }

        [TestMethod]
        public void MemberShouldSetCorrectName()
        {
            // Arrange & Act
            var testMember = new Member("Tosho");

            //Assert
            Assert.AreEqual("Tosho", testMember.Name);
        }

        [TestMethod]
        public void MemberShouldThrowEx()
        {
            //Arange, Act & Assert
            Assert.ThrowsException<ArgumentException>(
                () => new Member("Pepi"), "Member name must be between 5 and 15 characters long!");
        }


        [TestMethod]
        public void MemberShouldThrowExAndMessageWithNull()
        {
            //Arange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(
                 () => new Member(null), "Member name must not be null!");
        }
    }
}

