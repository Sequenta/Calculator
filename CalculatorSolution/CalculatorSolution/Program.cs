using System;
using System.Collections.Generic;
using BusinessLogic;
using JetBrains.Annotations;

namespace CalculatorSolution
{
    class Program
    {
        [UsedImplicitly]
        static void Main()
        {
            var pluginReader = new OperationPluginReader();
            var operations = pluginReader.ReadPluginsFrom(Environment.CurrentDirectory + "\\Plugins");
            var recognizer = new BaseRecognizer(operations);
            var calculator = new PostfixCalculator(recognizer);
            ShowAvailableOperations(calculator.GetAvailableOperations());
            var reader = new ConsoleInputReader();
            while (true)
            {
                var result = calculator.Calculate(reader.GetExpression());
                Console.WriteLine("Результат: {0}",result);
                Console.WriteLine("Нажмите Enter, чтобы продолжить или Esc, чтобы выйти");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }

        private static void ShowAvailableOperations(IEnumerable<string> availableOperations)
        {
            Console.WriteLine("Доступны следующие операции:");
            foreach (var availableOperation in availableOperations)
            {
                Console.WriteLine(availableOperation);
            }
        }
    }
}
