using BusinessLogic;
using Xunit;

namespace CalculatorSolution.Test.Calculation
{
    public class CalculationProcessTests
    {
        [Fact]
        public void GetOperator_ReturnsCorrectOperator()
        {
            var pluginReader = new OperationPluginReader();
            var operationsList = pluginReader.ReadPluginsFrom(System.Environment.CurrentDirectory + "\\Plugins");
            var recognizer = new BaseRecognizer(operationsList);
            var calculator = new PostfixCalculator(recognizer);

            var result = calculator.Calculate("2+2");

            Assert.Equal(4,result);
        }
    }
}