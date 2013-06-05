using BusinessLogic;
using Xunit;

namespace CalculatorSolution.Test.Calculation
{
    public class CalculationProcessTests
    {
        [Fact]
        public void Calculator_CanRecognizeDouble()
        {
            var calculator = new PostfixCalculator();

            var result = calculator.IsNumber("234");

            Assert.True(result);
        }
    }
}