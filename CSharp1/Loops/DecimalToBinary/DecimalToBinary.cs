namespace Loops
{
    /// <summary>
    /// Numeral systems 
    /// </summary>
    using System;

    public class DecimalToBinary
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            string text = null;
            if (num == 0)
            {
                Console.WriteLine("0");
            }
            while (num != 0)
            {
                text += num % 2;
                num /= 2;
            }

            char[] bits = text.ToCharArray();
            Array.Reverse(bits);
            text = new string(bits);
            Console.WriteLine(text);
        }
    }
}