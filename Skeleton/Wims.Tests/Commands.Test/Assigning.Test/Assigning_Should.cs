using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Models.Common;
using Wims.Core.Commands;
using Wims.Models;
using Wims.Core;

namespace Wims.Tests.Commands.Test.Assigning.Test
{
    [TestClass]
    public class Assigning_should
    {
        [TestMethod]
        public void Execute_Less_Params_ThrowEx()
        {
            //Arrange
            var listParams = new List<string>() { "TeamMemberName" };

            var sut = new AssignCommand(listParams);
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Parameters count is not valid!");
        }

        [TestMethod]
        public void Execute_Success()
        {
            //Arrange
            Commons.currentTeam = new Team("TeamName");
            Commons.currentBoard = new Board("BoardName");
            Commons.currentTeam.Boards.Add(Commons.currentBoard);
            var fakeMember = new Member("TestMemberName");
            var fakeCurrTeam = Commons.currentTeam;
            var fakeCurrBoard = Commons.currentBoard;
            fakeCurrTeam.Members.Add(fakeMember);
            var listParams = new List<string>() { "TestMemberName", "WorkItemTitle" };

            var workItem = new Bug("WorkItemTitle", "WorkItemDescription", Priority.High, Severity.Critical);
            fakeCurrBoard.WorkItems.Add(workItem);

            var sut = new AssignCommand(listParams);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.AreEqual(result, "TestMemberName has been assigned to WorkItemTitle");
        }

        [TestMethod]
        public void Execute_NonExistingMember_ThrowEx()
        {
            //Arrange
            Commons.currentTeam = new Team("TeamName");
            Commons.currentBoard = new Board("BoardName");
            Commons.currentTeam.Boards.Add(Commons.currentBoard);
            var fakeCurrTeam = Commons.currentTeam;
            var fakeCurrBoard = Commons.currentBoard;

            var listParams = new List<string>() { "TestMemberName", "WorkItemTitle" };

            var workItem = new Bug("WorkItemTitle", "WorkItemDescription", Priority.High, Severity.Critical);
            fakeCurrBoard.WorkItems.Add(workItem);

            var sut = new AssignCommand(listParams);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), $"Member with name TestMemberName does not exist in team {fakeCurrTeam.Name}.");
        }

        [TestMethod]
        public void Execute_NonExistingWorkItem_ThrowEx()
        {
            //Arrange
            Commons.currentTeam = new Team("TeamName");
            Commons.currentBoard = new Board("BoardName");
            Commons.currentTeam.Boards.Add(Commons.currentBoard);

            var fakeCurrTeam = Commons.currentTeam;
            var fakeCurrBoard = Commons.currentBoard;

            var listParams = new List<string>() { "TestMemberName", "WorkItemTitle" };

            var sut = new AssignCommand(listParams);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), $"Work item with title WorkItemTitle does not exist in board {fakeCurrBoard.Name}.");
        }

        [TestMethod]
        public void Execute_NonAssigneeType_ThrowEx()
        {
            //Arrange
            Commons.currentTeam = new Team("TeamName");
            Commons.currentBoard = new Board("BoardName");
            Commons.currentTeam.Boards.Add(Commons.currentBoard);
            var fakeMember = new Member("TestMemberName");
            var fakeCurrTeam = Commons.currentTeam;
            var fakeCurrBoard = Commons.currentBoard;
            fakeCurrTeam.Members.Add(fakeMember);
            var listParams = new List<string>() { "TestMemberName", "WorkItemTitle" };

            var workItem = new Feedback("WorkItemTitle", "WorkItemDescription", 3);
            fakeCurrBoard.WorkItems.Add(workItem);

            var sut = new AssignCommand(listParams);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), $"Work item WorkItemTitle is of type feedback and it is not supposed to have assignee.");
        }
    }
}
