using Domain;

namespace BusinessLogic
{
    /// <summary>
    /// Калькулятор, основанный на постфиксной нотации
    /// </summary>
    public class PostfixCalculator:ICalculator
    {
        public double Calculate(string expression)
        {
            return 234;
        }

        public bool IsNumber(string operand)
        {
            double number;
            var isNumber = double.TryParse(operand, out number);
            return isNumber;
        }
    }
}