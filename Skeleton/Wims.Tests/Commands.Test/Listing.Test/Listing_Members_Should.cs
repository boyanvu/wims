using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core.Commands;
using Wims.Models;

namespace Wims.Tests.Commands.Test.Listing.Test
{
    [TestClass]
    public class Listing_Members_Should
    {
        [TestMethod]
        public void ThrowWhen_NoMembers()
        {
            //Arrange
            var fakeProvider = new FakeMemberProvider();
            var list = new List<string>();
            var sut = new ListAllMembersCommand(list, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void ReturnCorrectString()
        {
            //Arrange
            var fakeProvider = new FakeMemberProvider();
            var listParams = new List<string>();

            var member1 = new Member("Boian");
            var member2 = new Member("Radoslav");
            fakeProvider.Add(member1);
            fakeProvider.Add(member2);

            var sut = new ListAllMembersCommand(listParams, fakeProvider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.IsTrue(result.StartsWith($"Boian"));
        }


      
    }
}