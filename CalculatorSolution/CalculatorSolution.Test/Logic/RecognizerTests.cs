using BusinessLogic;
using Domain;
using Xunit;

namespace CalculatorSolution.Test.Logic
{
    public class RecognizerTests
    {
        readonly IRecognizer recognizer = new BaseRecognizer();

        [Fact]
        public void GetFullNumber_ReturnsFullNumberFromExpression()
        {
            var result = recognizer.GetFullNumber("7904fss");
            Assert.Equal("7904",result);
        }

        [Fact]
        public void GetFullNumber_ReturnsFullNumberWithFloatingPointFromExpression()
        {
            var result = recognizer.GetFullNumber("56.57rhrdhr");
            Assert.Equal("56.57",result);
        }
    }
}