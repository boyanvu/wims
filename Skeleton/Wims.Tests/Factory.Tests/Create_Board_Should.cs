using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Factories;
using Wims.Models.Contracts;

namespace Wims.Tests.Factory.Tests
{
    [TestClass]
    public class Create_Board_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeBoard()
        {
            // Arrange
            var factory = new WimsFactory();

            // Act
            var board = factory.CreateBoard("Trello");

            // Assert
            Assert.IsInstanceOfType(board, typeof(IBoard));
        }
    }
}
