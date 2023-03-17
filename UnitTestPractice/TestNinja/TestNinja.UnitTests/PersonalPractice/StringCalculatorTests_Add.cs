using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.PersonalPractice;

namespace TestNinja.UnitTests.PersonalPractice
{
    [TestFixture]
    public class StringCalculatorTests_Add
    {
        private StringCalculator _calculator;

        [SetUp] 
        public void SetUp()
        {
            _calculator = new StringCalculator();
        }

        #region Step_1

        [Test]
        public void WhenEmptyString_ReturnsZero()
        {
            var result = _calculator.Add("");

            Assert.That(result, Is.Zero);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        public void WhenStringCanIncludeUpToTwoIntegers_ReturnsSumOfIntegers(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion

        #region Step_2

        [Test]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4,5", 15)]
        public void WhenStringCanIncludeAnUnknownNumberOfIntegers_ReturnsSumOfIntegers(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion

        #region Step_3

        [Test]
        [TestCase("1\n2,3", 6)]
        [TestCase("1,2,3\n4,5", 15)]
        public void WhenStringCanIncludeNewLinesNumberOfIntegers_ReturnsSumOfIntegers(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion

        #region Step_4

        [Test]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//k\n1k2k3\n4k5", 15)]
        public void WhenStringCanHandleAnyDelimiter_ReturnsSumOfIntegers(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion

        #region Step_5

        [Test]
        [TestCase("//;\n-1;2", "-1")]
        [TestCase("//k\n1k2k-3\n4k-5", "-3k-5")]
        public void WhenStringContainsNegativeNumber_ThrowsAnExceptionWithText(string numbers, string expectedMessage)
        {
            Assert.That(() => _calculator.Add(numbers), Throws.ArgumentException
                .With.Message.Contains(expectedMessage));
        }

        #endregion

        #region Step_6

        [Test]
        [TestCase("//;\n1;1001;2", 3)]
        [TestCase("//k\n1k2k1001k3\n4k5", 15)]
        public void WhenNumberGreaterThan1000_IgnoreNumber(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion

        #region Step_7

        [Test]
        [TestCase("//[|||]\n1|||1001|||2", 3)]
        [TestCase("//[lkm]\n1lkm2lkm1001lkm3\n4lkm5", 15)]
        public void WhenDelimiterString_ReturnsSumOfNumbers(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion

        #region Step_8/9

        [Test]
        [TestCase("//[|][%]\n1|2%3", 6)]
        [TestCase("//[|||][lkm]\n1|||2lkm3|||4lkm5", 15)]
        public void WhenMultipleDelimitersString_ReturnsSumOfNumbers(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion
    }
}
