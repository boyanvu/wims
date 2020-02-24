using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wims.Models.Common;

namespace Wims.Tests.Models.Tests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void SetCorrectStoryProperties()
        {
            // Arrange, act
            var story = new Story("NewCreatedStory", "NewCreateStoryDescription", Priority.High, Size.Large);

            //Assert
            Assert.AreEqual("NewCreatedStory", story.Title);
            Assert.AreEqual("NewCreateStoryDescription", story.Description);
            Assert.AreEqual(Priority.High, story.Priority);
            Assert.AreEqual(Size.Large, story.Size);
            Assert.AreEqual(StatusStory.NotDone, story.Status);
            Assert.AreEqual(null, story.Assignee);
        }

        [TestMethod]
        public void ReturnsCorrectTypeStory()
        {
            // Arrange, act
            var story = new Story("NewCreatedStory", "NewCreateStoryDescription", Priority.High, Size.Large);

            //Assert
            Assert.IsInstanceOfType(story, typeof(Story));
        }

        [TestMethod]
        public void ThrowWhenTheTitleIsNull()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentNullException>(()
                => new Story(null, "NewCreateStoryDescription", Priority.High, Size.Large));
        }

        [TestMethod]
        public void ThrowWhenTheTitleIsOutOfRange()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => new Story("Title", "NewCreateStoryDescription", Priority.High, Size.Large));
        }

        [TestMethod]
        public void ThrowWhenTheDescriptionIsNull()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentNullException>(()
                => new Story("NewCreatedStory", null, Priority.High, Size.Large));
        }

        [TestMethod]
        public void ThrowWhenTheDescriptionIsOutOfRange()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => new Story("NewCreatedStory", "Descr", Priority.High, Size.Large));
        }
    }
}
