using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core.Commands;
using Wims.Models;
using Wims.Models.Common;

namespace Wims.Tests.Commands.Test.Listing.Test
{
    [TestClass]
    public class FilterAllBugsByAssignee_Should
    {
        [TestMethod]
        public void FilterAllBugsByAssignee_Success()
        {
            //Arrange
            var member = new Member("TestMemberName");
            var fakeWorkItemProvider = new FakeWorkItemProvider();
            var fakeMemberProvider = new FakeMemberProvider();
            fakeMemberProvider.Add(member);
            var bug = new Bug("TestBugTitle", "TestBugDescription", Priority.High, Severity.Critical);
            bug.Assignee = member;
            fakeWorkItemProvider.Add(bug);

            var list = new List<string>() { "TestMemberName" };
            var sut = new FilterAllBugsByAssigneeCommand(list, fakeWorkItemProvider, fakeMemberProvider);

            //Act
            var result = sut.Execute();
            //Assert
            Assert.IsTrue(result.IndexOf("TestMemberName") > 0);
        }

        [TestMethod]
        public void FilterAllBugsByAssignee_Execute_Less_Params_ThrowEx()
        {
            //Arrange
            var fakeWorkItemProvider = new FakeWorkItemProvider();
            var fakeMemberProvider = new FakeMemberProvider();
            var list = new List<string>();

            var sut = new FilterAllBugsByAssigneeCommand(list, fakeWorkItemProvider, fakeMemberProvider);
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void FilterAllBugsByAssignee_Execute_NoBugsAvailable_ThrowEx()
        {
            //Arrange
            var member = new Member("TestMemberName");
            var fakeWorkItemProvider = new FakeWorkItemProvider();
            var fakeMemberProvider = new FakeMemberProvider();
            fakeMemberProvider.Add(member);

            var list = new List<string>() { "TestMemberName" };
            var sut = new FilterAllBugsByAssigneeCommand(list, fakeWorkItemProvider, fakeMemberProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void FilterAllBugsByAssignee_Execute_MemberDoesNotExists_ThrowEx()
        {
            //Arrange
            var fakeWorkItemProvider = new FakeWorkItemProvider();
            var fakeMemberProvider = new FakeMemberProvider();
            var bug = new Bug("TestBugTitle", "TestBugDescription", Priority.High, Severity.Critical);
            fakeWorkItemProvider.Add(bug);

            var list = new List<string>() { "TestMemberName" };
            var sut = new FilterAllBugsByAssigneeCommand(list, fakeWorkItemProvider, fakeMemberProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }
    }
}

