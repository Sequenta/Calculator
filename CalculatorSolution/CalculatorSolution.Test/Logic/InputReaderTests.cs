using Domain;
using Moq;
using Xunit;

namespace CalculatorSolution.Test.Logic
{
    public class InputReaderTests
    {
        [Fact]
        public void Reader_ReturnsCorrectExpression()
        {
            var moqReader = new Mock<IExpressionInputReader>();
            moqReader.Setup(moq => moq.GetExpression()).Returns("2+3*5");
            var result = moqReader.Object.GetExpression();
            Assert.Equal("2+3*5",result);
        }
    }
}