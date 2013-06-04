using BusinessLogic;
using Domain;
using Xunit;

namespace CalculatorSolution.Test.Logic
{
    public class InputReaderTests
    {
        [Fact]
        public void Reader_ReturnsCorrectExpression()
        {
            IExpressionInputReader reader = new ConsoleInputReader();
            var result = reader.GetExpression();
            Assert.Equal("2+3*5",result);
        }
    }
}