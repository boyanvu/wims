using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core;
using Wims.Core.Commands.Modifying;
using Wims.Models;
using Wims.Models.Common;

namespace Wims.Tests.Commands.Test.Modifying.Test
{
    [TestClass]
    public class Steps_To_Bug_Should
    {

        [TestMethod]
        public void ThrowWhen_NoItemsInBoard()
        {
            //Arrange
            var list = new List<string>();
            var sut = new AddStepsToBugCommand(list);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Execute_Less_Params_ThrowEx()
        {
            var listParams = new List<string>() { };
            var sut = new AddStepsToBugCommand(listParams);
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Parameters count is not valid!");
        }

        [TestMethod]
        public void ReturnCorrectString()
        {
            //Arrange
            var board = new Board("Trello");
            var bug = new Bug("NewCreatedBug", "NewCreateBugDescription", Priority.High, Severity.Minor);
            var listParams = new List<string>() { "NewCreatedBug", "first step>", "second step>", "third step" };
            Commons.currentBoard = board;
            var currBoardItems = Commons.currentBoard.WorkItems;
            currBoardItems.Add(bug);
            var sut = new AddStepsToBugCommand(listParams);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.AreEqual(result, $"Steps to reproduce have been added to bug NewCreatedBug.");
        }


    }
}