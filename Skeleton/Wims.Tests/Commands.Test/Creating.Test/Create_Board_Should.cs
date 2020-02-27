using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core;
using Wims.Core.Commands;
using Wims.Models;

namespace Wims.Tests.Commands.Test.Creating.Test
{
    [TestClass]
    public class Create_Board_Should
    {
        [TestMethod]
        public void CreateBoardSuccess()
        {
            //Arrange
            Commons.currentTeam = new Team("FakeTeamName");
            var list = new List<string>() { "BoardName" };
            var fakeBoardProvider = new FakeBoardProvider();

            var sut = new CreateBoardCommand(list, fakeBoardProvider);
            //Act
            var result = sut.Execute();
            //Assert
            Assert.IsTrue(result.StartsWith("Created Board"));
        }

        [TestMethod]
        public void BoardCreation_Execute_Less_Params_ThrowEx()
        {
            //Arrange
            var list = new List<string>();
            var fakeBoardProvider = new FakeBoardProvider();

            var sut = new CreateBoardCommand(list, fakeBoardProvider);
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Parameters count is not valid!");
        }

        [TestMethod]
        public void BoardCreation_Execute_BoardWithSameNameAlreadyExists_ThrowEx()
        {
            //Arrange
            Commons.currentTeam = new Team("FakeTeamName");
            var list = new List<string>() { "BoardName" };
            var fakeBoardProvider = new FakeBoardProvider();
            fakeBoardProvider.Add(new Board("BoardName"));

            var sut = new CreateBoardCommand(list, fakeBoardProvider);

            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Board with name BoardName already exists." + Environment.NewLine +
                              $"You can see all available boards with command listboards.");
        }
    }
}
