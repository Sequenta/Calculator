using System;
using BusinessLogic;
using Xunit;

namespace CalculatorSolution.Test.Calculation
{
    public class CalculationProcessTests
    {
        private readonly PostfixCalculator calculator;
        public CalculationProcessTests()
        {
            var pluginReader = new OperationPluginReader();
            var operationsList = pluginReader.ReadPluginsFrom(Environment.CurrentDirectory + "\\Plugins");
            var recognizer = new BaseRecognizer(operationsList);
            calculator = new PostfixCalculator(recognizer);
        }

        [Fact]
        public void Calculator_CalculatesSimpleExpressionProperly()
        {
            var result = calculator.Calculate("2+2");
            Assert.Equal(4,result);
        }

        [Fact]
        public void Calculator_CalculatesSimpleExpressionWithFloatingPoinNumbersProperly()
        {
            var result = calculator.Calculate("2.5+2.5");
            Assert.Equal(5, result);
        }

        [Fact]
        public void Calculator_CalculatesExpressionWithMultipleOperationsProperly()
        {
            var result = calculator.Calculate("2+6*10-2");
            Assert.Equal(60, result);
        }

        [Fact]
        public void Calculator_CalculatesExpressionWithMultipleOperationsAndFloatingPointNumbersProperly()
        {
            var result = calculator.Calculate("2.1+6.3*5.5-2.5");
            Assert.Equal(34.25, result);
        }

        [Fact]
        public void Calculator_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => calculator.Calculate("2//2"));
        }

        [Fact]
        public void Calculator_ReordersOperandsInCorrectOrder()
        {
            var result = calculator.ReorderInPostfixNotation(new[]{"2","+","6","*","10","-","2"});
            Assert.Equal(new[]{"2","6","10","*","2","-","+"}, result);
        }
    }
}