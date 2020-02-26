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
    public class Assigning_Should
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
            CurrentVariables.currentTeam = new Team("TeamName");
            CurrentVariables.currentBoard = new Board("BoardName");
            CurrentVariables.currentTeam.Boards.Add(CurrentVariables.currentBoard);
            var fakeMemberName = "TestMemberName";
            var fakeWiTitle = "WorkItemTitle";
            var fakeMember = new Member(fakeMemberName);
            var fakeCurrTeam = CurrentVariables.currentTeam;
            var fakeCurrBoard = CurrentVariables.currentBoard;
            fakeCurrTeam.Members.Add(fakeMember);
            var listParams = new List<string>() { fakeMemberName, fakeWiTitle };

            var workItem = new Bug(fakeWiTitle, "WorkItemDescription", Priority.High, Severity.Critical);
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
            CurrentVariables.currentTeam = new Team("TeamName");
            CurrentVariables.currentBoard = new Board("BoardName");
            CurrentVariables.currentTeam.Boards.Add(CurrentVariables.currentBoard);
            var fakeMemberName = "TestMemberName";
            var fakeWiTitle = "WorkItemTitle";
            var fakeCurrTeam = CurrentVariables.currentTeam;
            var fakeCurrBoard = CurrentVariables.currentBoard;

            var listParams = new List<string>() { fakeMemberName, fakeWiTitle };

            var workItem = new Bug(fakeWiTitle, "WorkItemDescription", Priority.High, Severity.Critical);
            fakeCurrBoard.WorkItems.Add(workItem);

            var sut = new AssignCommand(listParams);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), $"Member with name {fakeMemberName} does not exist in team {fakeCurrTeam.Name}.");
        }

        [TestMethod]
        public void Execute_NonExistingWorkItem_ThrowEx()
        {
            //Arrange
            CurrentVariables.currentTeam = new Team("TeamName");
            CurrentVariables.currentBoard = new Board("BoardName");
            CurrentVariables.currentTeam.Boards.Add(CurrentVariables.currentBoard);
            var fakeMemberName = "TestMemberName";
            var fakeWiTitle = "WorkItemTitle";
            var fakeCurrTeam = CurrentVariables.currentTeam;
            var fakeCurrBoard = CurrentVariables.currentBoard;

            var listParams = new List<string>() { fakeMemberName, fakeWiTitle };

            var sut = new AssignCommand(listParams);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), $"Work item with title {fakeWiTitle} does not exist in board {fakeCurrBoard.Name}.");
        }

        [TestMethod]
        public void Execute_NonAssigneeType_ThrowEx()
        {
            //Arrange
            CurrentVariables.currentTeam = new Team("TeamName");
            CurrentVariables.currentBoard = new Board("BoardName");
            CurrentVariables.currentTeam.Boards.Add(CurrentVariables.currentBoard);
            var fakeMemberName = "TestMemberName";
            var fakeWiTitle = "WorkItemTitle";
            var fakeMember = new Member(fakeMemberName);
            var fakeCurrTeam = CurrentVariables.currentTeam;
            var fakeCurrBoard = CurrentVariables.currentBoard;
            fakeCurrTeam.Members.Add(fakeMember);
            var listParams = new List<string>() { fakeMemberName, fakeWiTitle };

            var workItem = new Feedback(fakeWiTitle, "WorkItemDescription", 3);
            fakeCurrBoard.WorkItems.Add(workItem);

            var sut = new AssignCommand(listParams);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), $"Work item {fakeWiTitle} is of type feedback and it is not supposed to have assignee.");
        }
    }
}
