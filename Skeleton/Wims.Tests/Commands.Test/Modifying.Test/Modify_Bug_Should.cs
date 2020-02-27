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
    public class Modify_Bug_Should
    {
        [TestMethod]
        public void ModifyBugCommand_Success()
        {
            //Arrange
            var bugToModify = new Bug("testBugTitle", "testBugDescription", Priority.High, Severity.Critical);
            Commons.currentBoard = new Board("BoardName");
            Commons.currentBoard.WorkItems.Add(bugToModify);
            var wiPrivider = new FakeWorkItemProvider();
            var commandParams = new List<string>() { "testBugTitle", "priority", "Low" };
            var sut = new ModifyBugCommand(commandParams, wiPrivider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.AreEqual(result, "testBugTitle bug's priority was modified to Low in BoardName board!");
        }

        [TestMethod]
        public void ModifyBugCommand_WrongParameterToModify_ThrowEx()
        {
            //Arrange
            var bugToModify = new Bug("testBugTitle", "testBugDescription", Priority.High, Severity.Critical);
            Commons.currentBoard = new Board("BoardName");
            Commons.currentBoard.WorkItems.Add(bugToModify);
            var wiPrivider = new FakeWorkItemProvider();
            var commandParams = new List<string>() { "testBugTitle", "FakeParameter", "Low" };
            var sut = new ModifyBugCommand(commandParams, wiPrivider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Invalid parameter to modify." + Environment.NewLine + "You can modify priority, status or severity.");
        }

        [TestMethod]
        public void ModifyBugCommand_LessParameters_ThrowEx()
        {
            //Arrange
            var wiPrivider = new FakeWorkItemProvider();
            var commandParams = new List<string>() { "testBugTitle", "Low" };
            var sut = new ModifyBugCommand(commandParams, wiPrivider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Parameters count is not valid!");
        }
    }
}
