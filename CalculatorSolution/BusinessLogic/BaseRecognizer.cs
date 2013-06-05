using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace BusinessLogic
{
    /// <summary>
    /// Распознаватель операций и операндов
    /// </summary>
    public class BaseRecognizer:IRecognizer
    {
        private List<IOperation> operations;

        public BaseRecognizer() : this(null)
        {
        }

        public BaseRecognizer(List<IOperation> operationsList)
        {
            operations = operationsList;
        }

        public string GetFullNumber(string expression)
        {
            var recognizedNumber = new StringBuilder();
            foreach (var character in expression)
            {
                if (char.IsDigit(character) || character == '.' || character == ',')
                {
                    recognizedNumber.Append(character);
                }
                else
                {
                    return recognizedNumber.ToString();
                }
            }
            return recognizedNumber.ToString();
        }

        public string GetFullOperation(string expression)
        {
            foreach (var operation in operations)
            {
                var operatorLength = operation.StringPresentation.Length;
                var operationSubstring = expression.Substring(0, operatorLength);
                if (operationSubstring == operation.StringPresentation)
                {
                    var recognizedOperation = operationSubstring;
                    return recognizedOperation;
                }
            }
            throw new UnrecognizedOperationException();
        }

        public List<string> Recognize(string expression)
        {
            var operands = new List<string>();
            int nextCharacterPosition;
            for (var i = 0; i < expression.Length; i += nextCharacterPosition)
            {
                var character = expression[i];
                var recognizedOperand = "";
                if (char.IsDigit(character))
                {
                    recognizedOperand = GetFullNumber(expression.Substring(i, expression.Length - i));
                }
                else
                {
                    recognizedOperand = GetFullOperation(expression.Substring(i, expression.Length - i));
                }
                operands.Add(recognizedOperand);
                nextCharacterPosition = recognizedOperand.Length;
            }
            return operands;
        }

        public IOperation GetOperation(string operand)
        {
            foreach (var operation in operations.Where(operation => operand == operation.StringPresentation))
            {
                return operation;
            }
            throw new UnrecognizedOperationException();
        }

        public int GetOperationPriority(string operationString)
        {
            var operation = GetOperation(operationString);
            return operation.Priority;
        }

        public List<string> GetAvailableOperations()
        {
            return operations.Select(operation => operation.StringPresentation).ToList();
        }
    }
}