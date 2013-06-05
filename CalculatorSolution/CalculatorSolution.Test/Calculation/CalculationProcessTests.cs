using System;
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
        public void Calculator_CalculatesExpressionWithMultipleOperationsAndFloatingPointNumbersProperly()
        {
            var pluginReader = new OperationPluginReader();
            var operationsList = pluginReader.ReadPluginsFrom(System.Environment.CurrentDirectory + "\\Plugins");
            var recognizer = new BaseRecognizer(operationsList);
            var calculator = new PostfixCalculator(recognizer);

            var result = calculator.Calculate("2.1+6.3*5.5-2.5");

            Assert.Equal(34.25, result);
        }

        [Fact]
        public void Calculator_ThrowsInvalidOperationException()
        {
            var pluginReader = new OperationPluginReader();
            var operationsList = pluginReader.ReadPluginsFrom(Environment.CurrentDirectory + "\\Plugins");
            var recognizer = new BaseRecognizer(operationsList);
            var calculator = new PostfixCalculator(recognizer);

            Assert.Throws<InvalidOperationException>(() => calculator.Calculate("2//2"));
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