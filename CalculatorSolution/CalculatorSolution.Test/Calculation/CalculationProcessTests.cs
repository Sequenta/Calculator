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
    }
}