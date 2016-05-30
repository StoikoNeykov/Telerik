namespace OperatorsandExpressions
{
    /// <summary>
    /// Program read number from the console and print its digits mixed and the digits sum.
    /// </summary>
    using System;

    public class FourDigits
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int count = num.ToString().Length;
            int sum = 0;
            int[] digits = new int[count];
            for (int i = 0; i < count; i++)
            {
                digits[i] = num % 10;
                sum += digits[i];
                num /= 10;
            }

            Console.WriteLine(sum);
            foreach (int element in digits)
            {
                Console.Write(element);
            }

            Console.WriteLine("\n{3}{0}{1}{2}", digits[3], digits[2], digits[1], digits[0]);
            Console.WriteLine("{0}{2}{1}{3}", digits[3], digits[2], digits[1], digits[0]);
        }
    }
}
