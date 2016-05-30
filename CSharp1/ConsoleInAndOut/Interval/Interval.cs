namespace ConsoleInAndOut
{
    /// <summary>
    /// Program print all numbers in interval that can be divided by 5 wit hreminder 0
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class Interval
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            short num1 = short.Parse(Console.ReadLine());
            short num2 = short.Parse(Console.ReadLine());
            int count = 0;
            for (int i = num1 + 1; i < num2; i++)
            {
                if (i % 5 == 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}