using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTests
    {
        [Test]
        public void GetOutput_DivisibleByThree_ReturnsFizz()
        {
            // Arrange
            //var fizzbuzz = new FizzBuzz();

            // Act
            var result = FizzBuzz.GetOutput(3);

            // Assert
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_DivisibleByFive_ReturnsBuzz()
        {
            // Arrange
            //var fizzbuzz = new FizzBuzz();

            // Act
            var result = FizzBuzz.GetOutput(5);

            // Assert
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_DivisibleByThreeAndFive_ReturnsFizzBuzz()
        {
            // Arrange
            //var fizzbuzz = new FizzBuzz();

            // Act
            var result = FizzBuzz.GetOutput(15);

            // Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_NotDisvisibleByThreeOrFive_ReturnsSameNumber()
        {
            // Arrange
            //var fizzbuzz = new FizzBuzz();

            // Act
            var result = FizzBuzz.GetOutput(16);

            // Assert
            Assert.That(result, Is.EqualTo("16"));
        }

    }
}
