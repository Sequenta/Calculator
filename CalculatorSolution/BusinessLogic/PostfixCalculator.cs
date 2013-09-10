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
        private readonly NumberFormatInfo numberFormatInfo;
        private readonly IRecognizer recognizer;

        public PostfixCalculator(IRecognizer recognizer)
        {
            numberFormatInfo = new NumberFormatInfo {NumberDecimalSeparator = "."};
            this.recognizer = recognizer;
        }

        /// <summary>
        /// Расчитывает выражение и выдает результат
        /// </summary>
        /// <param name="expression">строка выражения</param>
        /// <returns></returns>
        public double Calculate(string expression)
        {
            var operands = recognizer.Recognize(expression);
            var operandsQueue = ReorderInPostfixNotation(operands);
            var result = PerformCalculations(operandsQueue);
            return result;
        }

        /// <summary>
        /// Выполняет соответсвующие действия над операндами, в зависимости от их типа
        /// </summary>
        /// <param name="operandsQueue">очередь операндов, сформированная в постфиксной нотации</param>
        /// <returns></returns>
        private double PerformCalculations(Queue<string> operandsQueue)
        {
            double result = 0;
            var helperStack = new Stack<string>();
            while (operandsQueue.Count != 0)
            {
                var operand = operandsQueue.Dequeue();
                if (IsNumber(operand))
                {
                    helperStack.Push(operand);

                }
                else
                {
                    result = PerformOperation(operand, helperStack);
                }
            }
            return result;
        }

        /// <summary>
        /// Выполняет конкретную операцию над соответсвующим количеством операндов
        /// </summary>
        /// <param name="operand">строковое представление операции</param>
        /// <param name="helperStack">вспомогательный стек операндов</param>
        /// <returns></returns>
        private double PerformOperation(string operand, Stack<string> helperStack)
        {
            var currentOperation = recognizer.GetOperation(operand);
            var numberOfArguments = currentOperation.Arity;
            var arguments = new double[numberOfArguments];
            for (var i = 0; i < numberOfArguments; i++)
            {
                arguments[i] = double.Parse(helperStack.Pop(),NumberStyles.AllowDecimalPoint, numberFormatInfo);
            }
            var result = currentOperation.Perform(arguments);
            helperStack.Push(result.ToString(numberFormatInfo));
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
        public Queue<string> ReorderInPostfixNotation(IEnumerable<string> operands)
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
                    if (helperStack.Count > 0)
                    {
                        if (GetPriority(operand) <= GetPriority(helperStack.Peek()))
                            helperStack.Push(operand);
                        else
                        {
                            while (helperStack.Count > 0 && GetPriority(operand) > GetPriority(helperStack.Peek()))
                                resultQueue.Enqueue((helperStack.Pop()));
                            helperStack.Push(operand);
                        }
                    }
                    else
                        helperStack.Push(operand);
                }
            }
            foreach (var operand in helperStack)
            {
                resultQueue.Enqueue(operand);
            }
            return resultQueue;
        }

        private int GetPriority(string operation)
        {
            return recognizer.GetOperationPriority(operation);
        }

        public List<string> GetAvailableOperations()
        {
            return recognizer.GetAvailableOperations();
        }
    }
}