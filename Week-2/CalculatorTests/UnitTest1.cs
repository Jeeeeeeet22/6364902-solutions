using NUnit.Framework;
using System;
using CalcLibrary;

namespace CalculatorTests
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        // ✅ Parameterized tests for Subtraction
        [TestCase(10, 5, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(-5, -5, 0)]
        [TestCase(100, 200, -100)]
        public void Subtraction_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var actual = calculator.Subtraction(a, b);
            Assert.AreEqual(expected, actual);
        }

        // ✅ Parameterized tests for Multiplication
        [TestCase(2, 3, 6)]
        [TestCase(-2, 3, -6)]
        [TestCase(0, 5, 0)]
        [TestCase(-4, -5, 20)]
        public void Multiplication_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var actual = calculator.Multiplication(a, b);
            Assert.AreEqual(expected, actual);
        }

        // ✅ Parameterized tests for Division
        [TestCase(10, 2, 5)]
        [TestCase(0, 5, 0)]
        [TestCase(-10, -2, 5)]
        public void Division_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var actual = calculator.Division(a, b);
            Assert.AreEqual(expected, actual);
        }

        // ✅ Division by zero test
        [Test]
        public void Division_ByZero_ShouldThrowArgumentException()
        {
            try
            {
                calculator.Division(10, 0);
                Assert.Fail("Division by zero");
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
            }
        }

        // ✅ Void method test: AllClear
        [Test]
        public void TestAddAndClear_ShouldClearResult()
        {
            double sum = calculator.Addition(10, 20);
            Assert.AreEqual(30, sum);
            Assert.AreEqual(30, calculator.GetResult);

            calculator.AllClear();
            Assert.AreEqual(0, calculator.GetResult);
        }

        /*
         * ✅ Private Method Explanation:
         * The calculator does not expose private methods.
         * You always test public behavior only.
         * Internal logic is covered by testing public methods.
         */

        /*
         * ✅ Mocking Explanation:
         * If this calculator depended on a DB or File, use Moq to mock it.
         * Example: Moq<IMyDatabase> to fake DB calls for isolation.
         * Moq helps test ONLY the calculator logic, not real IO.
         */
    }
}
