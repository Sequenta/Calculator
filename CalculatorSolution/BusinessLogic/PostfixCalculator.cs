using System.Collections.Generic;
using System.Globalization;
using Domain;

namespace BusinessLogic
{
    /// <summary>
    /// Калькулятор, основанный на постфиксной нотации
    /// </summary>
    public class PostfixCalculator:ICalculator
    {
        private NumberFormatInfo numberFormatInfo;
        private IRecognizer recognizer;

        public PostfixCalculator(IRecognizer recognizer)
        {
            numberFormatInfo = new NumberFormatInfo {NumberDecimalSeparator = "."};
            this.recognizer = recognizer;
        }
        public double Calculate(string expression)
        {
            var operands = recognizer.Recognize(expression);
            var operandsQueue = ReorderInPostfixNotation(operands);
            var result = PerformCalculations(operandsQueue);
            return result;
        }

        /// <summary>
        /// Оперделяет, является ли входная строка числом
        /// </summary>
        /// <param name="operand">строка операнда</param>
        /// <returns></returns>
        private bool IsNumber(string operand)
        {
            double number;
            var isNumber = double.TryParse(operand,NumberStyles.AllowDecimalPoint,numberFormatInfo, out number);
            return isNumber;
        }

        /// <summary>
        /// Строит из операндов очередь в соответствии с постфиксной нотацией
        /// </summary>
        /// <param name="operands">массив операндов</param>
        /// <returns>очередь в постфиксной нотации</returns>
        private Queue<string> ReorderInPostfixNotation(List<string> operands)
        {
            var resultQueue = new Queue<string>();
            var helperStack = new Stack<string>();
            foreach (var operand in operands)
            {
                if (IsNumber(operand))
                {
                    resultQueue.Enqueue(operand);
                }
                else
                {
                    helperStack.Push(operand);
                }
            }
            foreach (var operand in helperStack)
            {
                resultQueue.Enqueue(operand);
            }
            return resultQueue;
        }
    }
}