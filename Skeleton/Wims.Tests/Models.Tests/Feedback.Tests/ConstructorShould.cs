using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wims.Models;

namespace Wims.Tests.Models.Tests
{
    [TestClass]
    public class Feedback_ConstructorShould
    {
        [TestMethod]
        public void SetCorrectFeedbackProperties()
        {
            var feedback = new Feedback("NewCreatedFeedback", "NewCreatedFeedDescr", 5);

            Assert.AreEqual("NewCreatedFeedback", feedback.Title);
            Assert.AreEqual("NewCreatedFeedDescr", feedback.Description);
            Assert.AreEqual(5, feedback.Rating);
        }

        [TestMethod]
        public void ReturnsCorrectTypeFeedback()
        {
            var feedback = new Feedback("NewCreatedFeedback", "NewCreatedFeedDescr", 5);

            //Assert
            Assert.IsInstanceOfType(feedback, typeof(Feedback));
        }

        [TestMethod]
        public void ThrowWhenTheTitleIsNull()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentNullException>(()
                => new Feedback(null, "NewCreatedFeedDescr", 5));
        }

        [TestMethod]
        public void ThrowWhenTheTitleIsOutOfRange()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => new Feedback("Title", "NewCreatedFeedDescr", 5));
        }

        [TestMethod]
        public void ThrowWhenTheDescriptionIsNull()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentNullException>(()
                => new Feedback("NewCreatedFeedback", null, 5));
        }

        [TestMethod]
        public void ThrowWhenTheDescriptionIsOutOfRange()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => new Feedback("NewCreatedFeedback", "Descr", 5));
        }

        [TestMethod]
        public void ThrowWhenTheRatingIsOutOfRange()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => new Feedback("NewCreatedFeedback", "NewCreatedFeedDescr", 15));
        }
    }
}
