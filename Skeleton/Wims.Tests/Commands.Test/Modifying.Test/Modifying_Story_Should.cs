using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Core;
using Wims.Core.Commands;
using Wims.Core.Contracts;
using Wims.Models;
using Wims.Models.Common;
using Wims.Models.Contracts;

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
            CurrentVariables.currentBoard = board;
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
            CurrentVariables.currentBoard = board;
            var currBoardItems = CurrentVariables.currentBoard.WorkItems;
            currBoardItems.Add(story);
            var sut = new ModifyStoryCommand(listParams, fakeProvider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.AreEqual(result, "CreatedNewStory story's size was modified to medium in Trello board!");
        }


        class FakeWorkItemProvider : IWorkItemProvider
        {
            private readonly List<IWorkItem> workItems = new List<IWorkItem>();
            public IReadOnlyList<IWorkItem> WorkItems => workItems;

            public void Add(IWorkItem item)
            {
                workItems.Add(item);
            }

            public IWorkItem Find(string title)
            {
                var wi = workItems.FirstOrDefault(m => m.Title == title);
                return wi;
            }
        }
    }
}