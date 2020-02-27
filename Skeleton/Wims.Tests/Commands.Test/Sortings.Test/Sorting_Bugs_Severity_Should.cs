using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wims.Core.Commands;
using Wims.Models;
using Wims.Models.Common;
using Wims.Tests.Commands.Test;

namespace Wims.Tests.Commands.Tests.Sorting.Tests.SortBugsBySeverityCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ThrowWhen_NoItemsInBoard()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();
            var list = new List<string>();
            var sut = new SortBugsBySeverityCommand(list, fakeProvider);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void ReturnCorrectString()
        {
            //Arrange
            var fakeProvider = new FakeWorkItemProvider();

            var listParams = new List<string>();
            //string title, string description, Priority priority, Severity severity
            var bug1 = new Bug("WindowsCrash", "Description", Priority.High, Severity.Critical);
            var bug2 = new Bug("CrashCrash", "NovDescription", Priority.Low, Severity.Minor);
            fakeProvider.Add(bug1);
            fakeProvider.Add(bug2);
            var sut = new SortBugsBySeverityCommand(listParams, fakeProvider);

            //Act
            var result = sut.Execute();

            //Assert
            Assert.IsTrue(result.StartsWith($"Bug:{Environment.NewLine}  Title: WindowsCrash"));
        }
    }

}
