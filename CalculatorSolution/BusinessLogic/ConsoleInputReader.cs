using System;
using Domain;

namespace BusinessLogic
{
    /// <summary>
    /// Считыватель выражений из консоли
    /// </summary>
    public class ConsoleInputReader:IExpressionInputReader
    {
        public string GetExpression()
        {
            Console.WriteLine("Введите выражение и нажмите Enter");
            var expression = Console.ReadLine();
            return expression;
        }
    }
}