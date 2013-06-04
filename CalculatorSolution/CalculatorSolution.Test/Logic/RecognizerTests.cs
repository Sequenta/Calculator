using System.Collections.Generic;
using BusinessLogic;
using Domain;
using Moq;
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

        [Fact]
        public void GetFullOperation_ReturnsRecognizedOperation()
        {
            var moqOperation = new Mock<IOperation>();
            moqOperation.Setup(operation => operation.StringPresentation).Returns("+");
            var operationsList = new List<IOperation> {moqOperation.Object};
            IRecognizer recognizer = new BaseRecognizer(operationsList);

            var result = recognizer.GetFullOperation("+56");

            Assert.Equal("+",result);
        }

        [Fact]
        public void GetFullOperation_ThrowsUnrecognizedOperationException()
        {
            var moqOperation = new Mock<IOperation>();
            moqOperation.Setup(operation => operation.StringPresentation).Returns("+");
            var operationsList = new List<IOperation> {moqOperation.Object};
            IRecognizer recognizer = new BaseRecognizer(operationsList);

            Assert.Throws<UnrecognizedOperationException>(() => recognizer.GetFullOperation("-23"));
        }

        [Fact]
        public void Recognize_ReturnsCorrectNumberOfOperands()
        {
            var moqFirstOperation = new Mock<IOperation>();
            moqFirstOperation.Setup(operation => operation.StringPresentation).Returns("+");
            var moqSecondOperation = new Mock<IOperation>();
            moqSecondOperation.Setup(operation => operation.StringPresentation).Returns("-");
            var operationsList = new List<IOperation> {moqFirstOperation.Object, moqSecondOperation.Object};
            IRecognizer recognizer = new BaseRecognizer(operationsList);

            var result = recognizer.Recognize("2+6-8");

            Assert.Equal(5,result.Count);
        }

        [Fact]
        public void Recognize_ReturnsCorrectRecognizedOperands()
        {
            var moqFirstOperation = new Mock<IOperation>();
            moqFirstOperation.Setup(operation => operation.StringPresentation).Returns("+");
            var moqSecondOperation = new Mock<IOperation>();
            moqSecondOperation.Setup(operation => operation.StringPresentation).Returns("-");
            var operationsList = new List<IOperation> { moqFirstOperation.Object, moqSecondOperation.Object };
            IRecognizer recognizer = new BaseRecognizer(operationsList);

            var result = recognizer.Recognize("2+6-8");

            Assert.Equal(new[] { "2", "+", "6", "-", "8" }, result);
        }
    }
}