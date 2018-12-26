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
    class MathTests
    {
        // Creating a variable for our object
        private Fundamentals.Math _math;

        // Using setup Attribute on a method to make it initialize a new Math object before every test is run. This method MUST BE PUBLIC
        [SetUp]
        public void SetUp()
        {
            _math = new Fundamentals.Math();
        }

        // These will be our parameterized tests. Test attribute and 3 test cases that have values to test each execution path. 
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //Assert.That(result, Is.Not.Empty); // Just making sure that the array returned is not empty

            //Assert.That(result.Count(), Is.EqualTo(3));
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);

        }





    }
}
