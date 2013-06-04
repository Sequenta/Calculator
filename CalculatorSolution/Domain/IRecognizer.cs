namespace Domain
{
    /// <summary>
    /// Интерфейс распознавателя выражений
    /// </summary>
    public interface IRecognizer
    {
        /// <summary>
        /// Выделяет строку числа из строки выражения 
        /// </summary>
        /// <param name="expression">строка выражения</param>
        /// <returns></returns>
        string GetFullNumber(string expression);

        /// <summary>
        /// Выделяет строку числа из строки выражения
        /// </summary>
        /// <param name="expression">строка выражения</param>
        /// <returns></returns>
        string GetFullOperation(string expression);
    }
}