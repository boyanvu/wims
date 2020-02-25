using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wims.Core;
using Wims.Core.Abstracts;
using Wims.Core.Contracts;
using Wims.Models.Contracts;

namespace Wims.Tests.Commands.Test.Creating.Test
{
    [TestClass]
    public class Create_Team_Should
    {
        [TestMethod]
        public void ThrowWhen_NoOtherTeams()
        {
            //Arrange
            var fakeProvider = new FakeTeamProvider();
            var list = new List<string>();
            var sut = new CreateTeamCommand(list, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Execute_Less_Params_ThrowEx()
        {
            var fakeProvider = new FakeTeamProvider();
            var listParams = new List<string>();

            var sut = new CreateTeamCommand(listParams, fakeProvider);
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Parameters count is not valid!");
        }


        [TestMethod]
        public void ReturnCorrectString()
        {
            //Arrange
            var fakeProvider = new FakeTeamProvider();
            var listParams = new List<string>() { "Ducks" };

            var sut = new CreateTeamCommand(listParams, fakeProvider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.AreEqual(result, $"Created Team{Environment.NewLine}Ducks" + CurrentVariables.CreateTeamText());
        }


        class FakeTeamProvider : ITeamProvider
        {
            private List<ITeam> teams => new List<ITeam>();

            public IReadOnlyList<ITeam> Teams => teams;

            public void Add(ITeam team)
            {
                teams.Add(team);
            }

            public ITeam Find(string name)
            {
                var team = teams.FirstOrDefault(t => t.Name == name);
                return team;
            }
        }
    }
}
