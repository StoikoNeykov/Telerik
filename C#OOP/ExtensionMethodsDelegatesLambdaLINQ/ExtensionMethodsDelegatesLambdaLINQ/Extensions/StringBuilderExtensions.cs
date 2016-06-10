namespace ExtensionMethodsDelegatesLambdaLINQ.Extensions
{
    /// <summary>
    /// Implement Substring on StringBuilder
    /// </summary>
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder input, int index, int lenght)
        {
            Validate(input, index, lenght);
            var output = new StringBuilder(input.ToString(index, lenght));
            return output;
        }

        public static StringBuilder Substring(this StringBuilder input, int index)
        {
            Validate(input, index);
            var output = new StringBuilder(input.ToString(index, input.Length - index));
            return output;
        }

        private static void Validate(StringBuilder input, int index, int lenght = 0)
        {
            if (index < 0 || index > input.Length)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }
            if (lenght < 0 || lenght > input.Length - index)
            {
                throw new ArgumentOutOfRangeException("Unacceptable lenght!");
            }
        }
    }
}
