using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new DemeritPointsCalculator();
        }
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowsArgumentOutOfRangeException(int speed)
        {
            Assert.That(() => calculator.CalculateDemeritPoints(speed),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(70, 1)]
        [TestCase(300, 47)]
        public void CalculateDemeritPoints_SpeedMoreOrEqualZeroUpToSpeedLimit_ReturnsPoints(int speed, int expecterPoints)
        {
            var result = calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expecterPoints));
        }
    }
}
