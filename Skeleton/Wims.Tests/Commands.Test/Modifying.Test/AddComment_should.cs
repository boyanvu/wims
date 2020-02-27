using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core;
using Wims.Core.Commands;
using Wims.Models;
using Wims.Models.Common;

namespace Wims.Tests.Commands.Test.Modifying.Test
{
    [TestClass]
    public class AddComment_Should
    {
        [TestMethod]
        public void AddComment_Success()
        {
            //Arrange
            CommonInstances.CreateTestInstances();
            var fakeMember = new Member("TestMemberName");
            var fakeCurrTeam = Commons.currentTeam;
            var fakeCurrBoard = Commons.currentBoard;
            fakeCurrTeam.Members.Add(fakeMember);
            var listParams = new List<string>() { "WorkItemTitle", "TestMemberName", "BlaBlaBla" };
            var workItem = new Bug("WorkItemTitle", "WorkItemDescription", Priority.High, Severity.Critical);
            fakeCurrBoard.WorkItems.Add(workItem);
            var fakeMemberProvider = new FakeMemberProvider();
            fakeMemberProvider.Add(fakeMember);

            var sut = new AddCommentCommand(listParams, fakeMemberProvider);

            //Act
            sut.Execute();

            //Assert
            Assert.AreEqual(1, workItem.Comments.Count);
        }

        [TestMethod]
        public void AddComment_NoWorkItemToAddCommentTo_ThrowEx()
        {
            //Arrange
            CommonInstances.CreateTestInstances();
            var fakeCurrBoard = Commons.currentBoard;
            var listParams = new List<string>() { "WorkItemTitle", "TestMemberName", "BlaBlaBla" };
            var workItem = new Bug("WorkItemTitle", "WorkItemDescription", Priority.High, Severity.Critical);
            var fakeMemberProvider = new FakeMemberProvider();

            var sut = new AddCommentCommand(listParams, fakeMemberProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "No items in this board!");
        }

        [TestMethod]
        public void AddComment_MemberNotInTheTeam_ThrowEx()
        {
            //Arrange
            CommonInstances.CreateTestInstances();
            var fakeMember = new Member("TestMemberName");
            var fakeCurrTeam = Commons.currentTeam;
            var fakeCurrBoard = Commons.currentBoard;
            var listParams = new List<string>() { "WorkItemTitle", "TestMemberName", "BlaBlaBla" };
            var workItem = new Bug("WorkItemTitle", "WorkItemDescription", Priority.High, Severity.Critical);
            fakeCurrBoard.WorkItems.Add(workItem);
            var fakeMemberProvider = new FakeMemberProvider();

            var sut = new AddCommentCommand(listParams, fakeMemberProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), $"Member with name TestMemberName does not exist in team {fakeCurrTeam.Name}.");
        }

        [TestMethod]
        public void AddComment_WorkItemNotInTheBoard_ThrowEx()
        {
            //Arrange
            CommonInstances.CreateTestInstances();
            var fakeMember = new Member("TestMemberName");
            var fakeCurrTeam = Commons.currentTeam;
            var fakeCurrBoard = Commons.currentBoard;
            var listParams = new List<string>() { "WorkItemTitle", "TestMemberName", "BlaBlaBla" };
            var fakeMemberProvider = new FakeMemberProvider();

            var sut = new AddCommentCommand(listParams, fakeMemberProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), $"Work item with title WorkItemTitle does not exist in board {fakeCurrBoard.Name}.");
        }

        [TestMethod]
        public void AddComment_ExecuteLessParams_ThrowEx()
        {
            //Arrange
            var listParams = new List<string>() { "WorkItemTitle", "TeamMemberName" };
            var fakeMemberProvider = new FakeMemberProvider();

            var sut = new AddCommentCommand(listParams, fakeMemberProvider);
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Parameters count is not valid!");
        }
    }
}
