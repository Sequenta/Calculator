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

        public PostfixCalculator()
        {
            numberFormatInfo = new NumberFormatInfo {NumberDecimalSeparator = "."};
        }
        public double Calculate(string expression)
        {
            return 234;
        }

        public bool IsNumber(string operand)
        {
            double number;
            var isNumber = double.TryParse(operand,NumberStyles.AllowDecimalPoint,numberFormatInfo, out number);
            return isNumber;
        }
    }
}