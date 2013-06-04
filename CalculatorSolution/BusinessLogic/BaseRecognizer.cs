using System.Text;
using Domain;

namespace BusinessLogic
{
    /// <summary>
    /// Распознаватель операций и операндов
    /// </summary>
    public class BaseRecognizer:IRecognizer
    {
        public string GetFullNumber(string expression)
        {
            var recognizedNumber = new StringBuilder();
            foreach (var character in expression)
            {
                if (char.IsDigit(character))
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
    }
}