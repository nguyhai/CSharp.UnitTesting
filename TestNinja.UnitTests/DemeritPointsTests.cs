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
    class DemeritPointsTests
    {
        private DemeritPointsCalculator _demerit;

        [SetUp]
        public void SetUp()
        {
            _demerit = new DemeritPointsCalculator();
        }

        // Use Test Cases for these 2
        [Test]
        [TestCase(-1)]
        [TestCase(301)]

        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowOutOfRangeException(int speed)
        {
            Assert.That(() => _demerit.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }


        [Test]
        public void CalculateDemeritPoints_SpeedIsEqualToZero_ReturnZero()
        {
            var result = _demerit.CalculateDemeritPoints(0);
            Assert.That(result, Is.EqualTo(0));
        }

        // Use Test Casees for these 3
        [Test]
        [TestCase(0,0)]
        [TestCase(15, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var result = _demerit.CalculateDemeritPoints(speed);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
