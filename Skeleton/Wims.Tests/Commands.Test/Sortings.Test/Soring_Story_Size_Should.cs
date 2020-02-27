using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core.Commands.Sorting;
using Wims.Models.Common;

namespace Wims.Tests.Commands.Test.Sortings.Test
{
    [TestClass]
    public class Sorting_Story_Size_Should
    {
        [TestMethod]
        public void ReturnCorrectString()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();

            var storyA = new Story("TitleStoryA", "DescriptionStoryA", Priority.High, Size.Small);
            var storyB = new Story("TitleStoryB", "DescriptionStoryB", Priority.High, Size.Large);

            fakeProvider.Add(storyA);
            fakeProvider.Add(storyB);

            var list = new List<string>();
            var sut = new SortStoriesBySizeCommand(list, fakeProvider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.IsTrue(result.StartsWith($"Story:{Environment.NewLine}  Title: TitleStoryB"));


        }

        [TestMethod]
        public void NoStoriesToBeSorted_ThrowEx()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();

            var list = new List<string>();
            var sut = new SortStoriesBySizeCommand(list, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "No items in this board!");


        }
    }
}
