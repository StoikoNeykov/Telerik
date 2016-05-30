namespace Loops
{
    /// <summary>
    /// Numeral systems transforms
    /// </summary>
    using System;

    public class HexToDecimal
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            char[] digits = text.ToCharArray();
            Array.Reverse(digits);
            Int64 result = 0;
            Int64 pow = 1;
            for (int i = 0; i < digits.Length; i++)
            {
                int curent;
                switch (digits[i])
                {
                    case 'A': curent = 10; break;
                    case 'B': curent = 11; break;
                    case 'C': curent = 12; break;
                    case 'D': curent = 13; break;
                    case 'E': curent = 14; break;
                    case 'F': curent = 15; break;
                    default: curent = digits[i] - '0'; break;
                }

                result += curent * pow;
                pow *= 16;
            }

            Console.WriteLine(result);
        }
    }
}