using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Factories;
using Wims.Models.Common;
using Wims.Models.Contracts;

namespace Wims.Tests.Factory.Tests
{
    [TestClass]
    public class Create_Story_Should
    {
        [TestMethod]
        public void ReturnInstanceOfTypeStory()
        {
            // Arrange
            var factory = new WimsFactory();

            // Act
            var story = factory.CreateStory("NewCreatedStory", "NewCreateBugStoryDescr", Priority.Low, Size.Small);

            // Assert
            Assert.IsInstanceOfType(story, typeof(IStory));
        }
    }
}
