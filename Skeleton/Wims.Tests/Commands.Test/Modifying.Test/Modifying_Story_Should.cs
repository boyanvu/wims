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
    public class Modify_Story_Should
    {
        [TestMethod]
        public void ThrowWhen_NoItemsInBoard()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();
            var list = new List<string>();
            var sut = new ModifyStoryCommand(list, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Execute_Less_Params_ThrowEx()
        {
            var fakeProvider = new FakeWorkItemProvider();
            var board = new Board("Trello");
            Commons.currentBoard = board;
            var listParams = new List<string>() { "CreatedNewStory", "CSDescription" };

            var sut = new ModifyStoryCommand(listParams, fakeProvider);
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Parameters count is not valid!");
        }

        [TestMethod]
        public void ReturnCorrectString()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();
            var board = new Board("Trello");
            var story = new Story("CreatedNewStory", "CSDescription", Priority.High, Size.Large);
            var listParams = new List<string>() { "CreatedNewStory", "size", "medium" };
            Commons.currentBoard = board;
            var currBoardItems = Commons.currentBoard.WorkItems;
            currBoardItems.Add(story);
            var sut = new ModifyStoryCommand(listParams, fakeProvider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.AreEqual(result, "CreatedNewStory story's size was modified to medium in Trello board!");
        }

        [TestMethod]
        public void ModifyStory_InvalidPropertyToModify_ThrowEx()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();
            var board = new Board("Trello");
            var story = new Story("CreatedNewStory", "CSDescription", Priority.High, Size.Large);
            var listParams = new List<string>() { "CreatedNewStory", "BlaBla", "medium" };
            Commons.currentBoard = board;
            var currBoardItems = Commons.currentBoard.WorkItems;
            currBoardItems.Add(story);
            var sut = new ModifyStoryCommand(listParams, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(()=>sut.Execute(), "Invalid parameter to modify." + Environment.NewLine + "You can modify priority, status or size.");
        }

        //throw new ArgumentException("Invalid parameter to modify." + Environment.NewLine + "You can modify priority, status or size.");
       
    }
}