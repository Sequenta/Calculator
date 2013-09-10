using System;
using System.Collections.Generic;
using System.IO;
using BusinessLogic;
using Domain;
using JetBrains.Annotations;

namespace CalculatorSolution
{
    [UsedImplicitly]
    class Program
    {
        static void Main()
        {
            var pluginReader = new OperationPluginReader();
            List<IOperation> operations;
            try
            {
                operations = pluginReader.ReadPluginsFrom(Environment.CurrentDirectory + "\\Plugins");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Ошибка! Отсутсвует директория Plugins");
                Console.WriteLine("Нажмите любую клавишу, чтобы выйти...");
                Console.ReadKey();
                return;
            }
            var recognizer = new BaseRecognizer(operations);
            var calculator = new PostfixCalculator(recognizer);
            ShowAvailableOperations(calculator.GetAvailableOperations());
            var reader = new ConsoleInputReader();
            while (true)
            {
                try
                {
                    var result = calculator.Calculate(reader.GetExpression());
                    Console.WriteLine("Результат: {0}",result);
                }
                catch (UnrecognizedOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
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
