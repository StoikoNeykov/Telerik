namespace ConsoleInAndOut
{
    /// <summary>
    /// Program printing Fibonacci numbers
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class FibonacciNumbers
    {
        public static double Fibonacci(byte n)
        {
            double a = 0;
            double b = 1;
            for (int i = 0; i < n; i++)
            {
                double temp = a;
                a = b;
                b += temp;
            }

            return a;
        }

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            byte n = byte.Parse(Console.ReadLine());
            for (byte i = 0; i < n; i++)
            {
                Console.Write(Fibonacci(i));
                if (i < n - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }
    }
}