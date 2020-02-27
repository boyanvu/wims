using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Models;
using Wims.Models.Common;
using Wims.Core.Commands;
using Wims.Core;

namespace Wims.Tests.Commands.Test.Assigning.Test
{
    [TestClass]
    public class Unassign_Should
    {
        [TestMethod]
        public void ThrowWhen_NoWorkItemsInBoard()
        {
            //Arrange
            var list = new List<string>();
            var sut = new UnassignCommand(list);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void ReturnCorrectString()
        {
            //Arrange
            //var team = new Team("Ducks");
            var board = new Board("Trello");
            //CurrentVariables.currentTeam = team;
            Commons.currentBoard = board;
            var currBoardItems = Commons.currentBoard;
            var story = new Story("NewCreatedStory", "NewCreateBugStoryDescr", Priority.Low, Size.Large);
            var member = new Member("Pesho");
            story.Assignee = member;
            currBoardItems.WorkItems.Add(story);
            var listParams = new List<string>() { story.Title };
            var sut = new UnassignCommand(listParams);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.AreEqual(result, "Pesho has been unassigned from NewCreatedStory");
        }

    }
}
