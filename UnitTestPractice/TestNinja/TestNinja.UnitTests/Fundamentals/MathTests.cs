using TestNinja.Fundamentals;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(-1, 2, 1)]
        [TestCase(-1, -2, -3)]
        public void Add_WhenCalled_ReturnsTheSumOfArguments(int a, int b, int expectedResult)
        {
            var result = _math.Add(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnsTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [Test]
        [TestCase(5, new[] { 1, 3, 5 })]
        [TestCase(0, new int[] { })]
        [TestCase(-1, new int[] { })]
        public void GetOddNumbers_WhenCalled_ReturnsTheCollectionOfOddNumbers(int limit, int[] expectedResult)
        {
            var result = _math.GetOddNumbers(limit);

            Assert.That(result, Is.EquivalentTo(expectedResult));
        }
    }
}
