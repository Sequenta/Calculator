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

            var result = calculator.Calculate("2+6*10-2");

            Assert.Equal(60, result);
        }

        [Fact]
        public void Calculator_ReordersOperandsInCorrectOrder()
        {
            var pluginReader = new OperationPluginReader();
            var operationsList = pluginReader.ReadPluginsFrom(System.Environment.CurrentDirectory + "\\Plugins");
            var recognizer = new BaseRecognizer(operationsList);
            var calculator = new PostfixCalculator(recognizer);

            var result = calculator.ReorderInPostfixNotation(new[]{"2","+","6","*","10","-","2"});

            Assert.Equal(new[]{"2","6","10","*","2","-","+"}, result);
        }
    }
}