using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }
    }
}