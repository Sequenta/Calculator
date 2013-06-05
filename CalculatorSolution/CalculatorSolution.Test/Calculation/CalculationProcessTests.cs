using BusinessLogic;
using Xunit;

namespace CalculatorSolution.Test.Calculation
{
    public class CalculationProcessTests
    {
        [Fact]
        public void Calculator_CalculatesSimpleExpressionProperly()
        {
            var pluginReader = new OperationPluginReader();
            var operationsList = pluginReader.ReadPluginsFrom(System.Environment.CurrentDirectory + "\\Plugins");
            var recognizer = new BaseRecognizer(operationsList);
            var calculator = new PostfixCalculator(recognizer);

            var result = calculator.Calculate("2+2");

            Assert.Equal(4,result);
        }

        [Fact]
        public void Calculator_CalculatesSimpleExpressionWithFloatingPoinNumbersProperly()
        {
            var pluginReader = new OperationPluginReader();
            var operationsList = pluginReader.ReadPluginsFrom(System.Environment.CurrentDirectory + "\\Plugins");
            var recognizer = new BaseRecognizer(operationsList);
            var calculator = new PostfixCalculator(recognizer);

            var result = calculator.Calculate("2.5+2.5");

            Assert.Equal(5, result);
        }

        [Fact]
        public void Calculator_CalculatesExpressionWithMultipleOperationsProperly()
        {
            var pluginReader = new OperationPluginReader();
            var operationsList = pluginReader.ReadPluginsFrom(System.Environment.CurrentDirectory + "\\Plugins");
            var recognizer = new BaseRecognizer(operationsList);
            var calculator = new PostfixCalculator(recognizer);

            var result = calculator.Calculate("1+6*10+5");

            Assert.Equal(66, result);
        }
    }
}