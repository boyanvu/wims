using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core.Commands;
using Wims.Models;
using Wims.Models.Common;

namespace Wims.Tests.Commands.Test.Sortings.Test
{
    [TestClass]
    public class Sorting_Bugs_Status_Should
    {
        [TestMethod]
        public void ThrowWhen_NoBugsInBoard()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();
            var list = new List<string>();
            var sut = new FilterAllBugsByStatusCommand(list, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Execute_Less_Params_ThrowEx()
        {
            var fakeProvider = new FakeWorkItemProvider();
            var listParams = new List<string>();
            var bug1 = new Bug("WindowsCrash", "Description", Priority.High, Severity.Critical);
            var bug2 = new Bug("CrashCrash", "NovDescription", Priority.Low, Severity.Minor);
            bug1.Status = StatusBug.Fixed;
            bug2.Status = StatusBug.Active;
            fakeProvider.Add(bug1);
            fakeProvider.Add(bug2);
            var sut = new FilterAllBugsByStatusCommand(listParams, fakeProvider);
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute(), "Parameters count is not valid!");
        }



        [TestMethod]
        public void ReturnCorrectString()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();
            var listParams = new List<string>() { "fixed" };

            var bug1 = new Bug("WindowsCrash", "Description", Priority.High, Severity.Critical);
            var bug2 = new Bug("CrashCrash", "NovDescription", Priority.Low, Severity.Minor);
            bug1.Status = StatusBug.Fixed;
            bug2.Status = StatusBug.Active;
            fakeProvider.Add(bug1);
            fakeProvider.Add(bug2);
            var sut = new FilterAllBugsByStatusCommand(listParams, fakeProvider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.IsTrue(result.StartsWith($"Bug:{Environment.NewLine}  Title: WindowsCrash"));

        }



     
    }
}