using BusinessLogic;
using Domain;
using Xunit;

namespace CalculatorSolution.Test.Logic
{
    public class RecognizerTests
    {
        [Fact]
        public void GetFullNumber_ReturnsFullNumberFromExpression()
        {
            IRecognizer recognizer = new BaseRecognizer();
            var result = recognizer.GetFullNumber("7904fss");
            Assert.Equal("7904",result);
        }

        [Fact]
        public void GetFullNumber_ReturnsFullNumberWithFloatingPointFromExpression()
        {
            IRecognizer recognizer = new BaseRecognizer();
            var result = recognizer.GetFullNumber("56.57rhrdhr");
            Assert.Equal("56.57",result);
        }
    }
}