namespace Loops
{
    /// <summary>
    /// Calculate how many zeroes have factorial of the number 
    /// (without actually calculate it - that will go out of time limits)
    /// </summary>
    using System;

    public class Trailing0inFactorial
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int zeroes = 0;
            int divider = 5;
            while (num / divider >= 1)
            {
                zeroes += num / divider;
                divider *= 5;
            }

            Console.WriteLine(zeroes);
        }
    }
}