using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Philosophers.Models;

namespace Philosophers.Tests
{
    [TestClass]
    public class PhilosopherTests
    {
        // Arrange test data
        Philosopher target1 = new Philosopher
        {
            PhilosopherID = 1,
            FirstName = "Test",
            LastName = "One",
            DateOfBirth = DateTime.Parse("1800-01-01"),
            DateOfDeath = DateTime.Parse("1850-01-01"),
            AreaID = 1,
            NationalityID = 1,
            Description = "Some text for test one"
        };

        Philosopher target2 = new Philosopher
        {
            PhilosopherID = 2,
            FirstName = "Test",
            LastName = "Two",
            DateOfBirth = DateTime.Parse("1950-01-01"),
            AreaID = 1,
            NationalityID = 1,
            Description = "Some text for test two"
        };

        [TestMethod]
        public void PhilosopherFullNameTest()
        {
            // Act
            var result = target1.FullName;

            // Assert
            Assert.AreEqual("Test One", result);
        }

        [TestMethod]
        public void PhilosopherImageURL()
        {
            // Act
            var result = target1.ImgUrl;

            // Assert
            Assert.AreEqual("1-One.jpg", result);
        }

        [TestMethod]
        public void PhilosopherAgeWhenDead()
        {
            // Act
            var result = target1.calculateAge();

            // Assert
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void PhilosopherAgeWhenAlive()
        {
            // Act
            var result = target2.calculateAge();

            // Assert
            Assert.AreEqual(66, result);
        }

    }
}
