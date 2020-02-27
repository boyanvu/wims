using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core.Commands;
using Wims.Models;

namespace Wims.Tests.Commands.Test.Listing.Test
{
    [TestClass]
    public class Listing_Boards_Should
    {
        [TestMethod]
        public void ThrowWhen_NoBoard()
        {
            //Arrange
            var fakeProvider = new FakeBoardProvider();
            var list = new List<string>();
            var sut = new ListAllBoardsCommand(list, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void ListAllBoards_Success()
        {
            //Arrange
            var fakeProvider = new FakeBoardProvider();
            var listParams = new List<string>();

            var board1 = new Board("Board1");
            var board2 = new Board("Board2");
            fakeProvider.Add(board1);
            fakeProvider.Add(board2);

            var sut = new ListAllBoardsCommand(listParams, fakeProvider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.IsTrue(result.StartsWith($"Board1"));
        }
    }
}