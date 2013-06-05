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

        [Fact]
        public void Calculator_ReordersOperandsInCorrectOrder()
        {
            var calculator = new PostfixCalculator();
            var result = calculator.ReorderInPostfixNotation(new List<string> { "3", "+", "7", "*", "2" });
            Assert.Equal(new[] { "3", "7", "2", "*", "+" }, result);
        }
    }
}