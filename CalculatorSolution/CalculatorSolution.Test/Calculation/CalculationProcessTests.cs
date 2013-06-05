using System.Collections.Generic;
using BusinessLogic;
using Xunit;

namespace CalculatorSolution.Test.Calculation
{
    public class CalculationProcessTests
    {
        [Fact]
        public void CalculatorIsNumber_ReturnsTrueWhenDouble()
        {
            var calculator = new PostfixCalculator();

            var result = calculator.IsNumber("234");

            Assert.True(result);
        }

        [Fact]
        public void CalculatorIsNumber_ReturnsTrueWhenFloatingPointDouble()
        {
            var calculator = new PostfixCalculator();

            var result = calculator.IsNumber("23.86");

            Assert.True(result);
        }
    }
}