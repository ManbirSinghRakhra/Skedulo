using HelloWorld.Interfaces;
using HelloWorld.Interfaces.InterfacesImpl;
using NUnit.Framework;
using System;

namespace HelloWorld.Tests
{
    [TestFixture]
    public class MathFunctionsTests
    {
        public IMathFunctions CreateDefaultMathFunctions()
        {
            return new MathFunctions();
        }


        [TestCase(16, 4, true)]
        [TestCase(64, 4, true)]
        public void DivisibleBy_SingleDivisibleNumbersBy4_ReturnTrue(double numbersInTest, double divisor, bool expected)
        {
            IMathFunctions iMathFunctions = CreateDefaultMathFunctions();
            var actual = iMathFunctions.DivisibleBy(numbersInTest, divisor);
            Assert.True(actual);
        }


        [TestCase(17, 4, true)]
        [TestCase(63, 4, true)]
        public void DivisibleBy_SingleNonDivisibleNumbersBy4_ReturnFalse(double numbersInTest, double divisor, bool expected)
        {
            IMathFunctions iMathFunctions = CreateDefaultMathFunctions();
            var actual = iMathFunctions.DivisibleBy(numbersInTest, divisor);
            Assert.False(actual);
        }


        [TestCase(15, 5, true)]
        [TestCase(60, 5, true)]
        public void DivisibleBy_SingleDivisibleNumbersBy5_ReturnTrue(double numbersInTest, double divisor, bool expected)
        {
            IMathFunctions iMathFunctions = CreateDefaultMathFunctions();
            var actual = iMathFunctions.DivisibleBy(numbersInTest, divisor);
            Assert.True(actual);
        }


        [TestCase(11, 5, true)]
        [TestCase(62, 5, true)]
        public void DivisibleBy_SingleDivisibleNumbersBy5_ReturnFalse(double numbersInTest, double divisor, bool expected)
        {
            IMathFunctions iMathFunctions = CreateDefaultMathFunctions();
            var actual = iMathFunctions.DivisibleBy(numbersInTest, divisor);
            Assert.False(actual);
        }

        [TestCase(11, 0)]
        public void DivisibleBy_ZeroDivisor_ThrowsDivideByExpection(double numbersInTest, double divisor)
        {
            IMathFunctions iMathFunctions = CreateDefaultMathFunctions();
            var ex = Assert.Throws<DivideByZeroException>(() => iMathFunctions.DivisibleBy(numbersInTest, divisor));
            Equals(ex.Message.Contains("Divisor cannot be Zero"));
        }
    }
}
