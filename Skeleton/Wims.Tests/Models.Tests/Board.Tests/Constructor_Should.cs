using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wims.Models;

namespace Wims.Tests.Models.Tests
{
    [TestClass]
    public class Board_Constructor_Should
    {
        [TestMethod]
        public void SetCorrectBoardName()
        {
            //Arrange
            var boardName = "Trello";

            //Act
            var board = new Board(boardName);

            //Assert
            Assert.AreEqual(boardName, board.Name);
        }

        [TestMethod]
        public void ThrowArgument_NullBoardName()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Board(null));
        }

        [TestMethod]
        public void ThrowArgument_InvalidBoardName()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Board("LongNameBoard"));
        }


    }
}
