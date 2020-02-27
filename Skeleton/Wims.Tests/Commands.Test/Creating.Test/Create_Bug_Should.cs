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
    public class Create_Bug_Should
    {
        [TestMethod]
        public void BugCreation_Execute_SameTitleAlreadyExists_ThrowEx()
        {
            //Arrange
            CommonInstances.CreateTestInstances();
            var fakeProvider = new FakeWorkItemProvider();

            var fakeCurrBoard = Commons.currentBoard;

            var listParams = new List<string>() { "WorkItemTitle", "WorkItemDescription", "High", "Critical" };

            var workItem = new Bug("WorkItemTitle", "WorkItemDescription", Priority.High, Severity.Critical);

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

            var fakeCurrBoard = Commons.currentBoard;

            var listParams = new List<string>() { "WorkItemTitle", "WorkItemDescription", "High", "Critical" };

            var sut = new CreateBugCommand(listParams, fakeProvider);

            var result = sut.Execute();

            //Act & Assert
            Assert.AreEqual(result, $"WorkItemTitle bug added to {fakeCurrBoard} board!" + Commons.CreateBugText());
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
