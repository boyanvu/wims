using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core.Commands;
using Wims.Models;
using Wims.Tests.Commands.Test;

namespace Wims.Tests.Commands.Tests.Sorting.Tests.SortingsRatingsCommand
{
    [TestClass]
    public class Sorting_Rating_Should
    {
        [TestMethod]
        public void ThrowWhen_NoItemsInBoard()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();
            var list = new List<string>();
            var sut = new SortAllItemsByRatingCommand(list, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void ReturnCorrectString()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();
            var listParams = new List<string>();

            var feedback1 = new Feedback("NewFeedback1", "Feed1Description", 5);
            var feedback2 = new Feedback("NewFeedback2", "Feed2Descriptin", 9);
            fakeProvider.Add(feedback1);
            fakeProvider.Add(feedback2);

            var sut = new SortAllItemsByRatingCommand(listParams, fakeProvider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.IsTrue(result.StartsWith($"Feedback:{Environment.NewLine}  Title: NewFeedback1"));
        }
    }

}
