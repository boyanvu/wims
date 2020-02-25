using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wims.Core;
using Wims.Core.Commands;
using Wims.Core.Contracts;
using Wims.Models;
using Wims.Models.Contracts;

namespace Wims.Tests.Commands.Test.Creating.Test
{
    public class Create_Story_Should
    {
        [TestMethod]
        public void ThrowWhen_NoItemsInBoard()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();
            var list = new List<string>();
            var sut = new CreateStoryCommand(list, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Execute_Less_Params_ThrowEx()
        {
            var fakeProvider = new FakeWorkItemProvider();
            var listParams = new List<string>() { "CreatedNewStory", "CSDescription", "high" }; ;

            var sut = new CreateStoryCommand(listParams, fakeProvider);
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Parameters count is not valid!");
        }


        [TestMethod]
        public void ReturnCorrectString()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();
            var board = new Board("Trello");
            var listParams = new List<string>() { "CreatedNewStory", "CSDescription", "high", "large" };
            CurrentVariables.currentBoard = board;
            var sut = new CreateStoryCommand(listParams, fakeProvider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.AreEqual(result, $"CreatedNewStory story added to Trello board!" + CurrentVariables.CreateStoryText());
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
