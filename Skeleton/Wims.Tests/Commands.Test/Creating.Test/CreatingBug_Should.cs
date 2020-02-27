using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core;
using Wims.Core.Commands;
using Wims.Models;
using Wims.Models.Common;

namespace Wims.Tests.Commands.Test.Creating.Test
{
    [TestClass]
    public class CreatingBug_Should
    {
        [TestMethod]
        public void BugCreation_Execute_SameTitleAlreadyExists_ThrowEx()
        {
            //Arrange
            CommonInstances.CreateTestInstances();
            var fakeProvider = new FakeWorkItemProvider();
            var fakeWiTitle = "WorkItemTitle";

            var fakeCurrBoard = CurrentVariables.currentBoard;

            var listParams = new List<string>() { fakeWiTitle, "WorkItemDescription", "High", "Critical" };

            var workItem = new Bug(fakeWiTitle, "WorkItemDescription", Priority.High, Severity.Critical);

            fakeProvider.Add(workItem);

            var sut = new CreateBugCommand(listParams, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Bug already exists!");
        }

        [TestMethod]
        public void BugCreation_Execute_Success()
        {
            //Arrange
            CommonInstances.CreateTestInstances();
            var fakeProvider = new FakeWorkItemProvider();
            var fakeWiTitle = "WorkItemTitle";

            var fakeCurrTeam = CurrentVariables.currentTeam;
            var fakeCurrBoard = CurrentVariables.currentBoard;

            var listParams = new List<string>() { fakeWiTitle, "WorkItemDescription", "High", "Critical" };

            var sut = new CreateBugCommand(listParams, fakeProvider);

            var result = sut.Execute();

            //Act & Assert
            Assert.AreEqual(result, $"{fakeWiTitle} bug added to {fakeCurrBoard} board!" + CurrentVariables.CreateBugText());
        }

        [TestMethod]
        public void BugCreation_Execute_Less_Params_ThrowEx()
        {
            //Arrange
            var listParams = new List<string>() { "TitleForTest", "WorkItemDescription", "High" };
            var fakeWiProv = new FakeWorkItemProvider();
            var sut = new CreateBugCommand(listParams, fakeWiProv);
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Parameters count is not valid!");
        }
    }
}
