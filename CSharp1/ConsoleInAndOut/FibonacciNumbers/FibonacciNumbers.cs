using System;
using System.Globalization;
using System.Threading;

    class FibonacciNumbers
{
    public static double fibonacci (byte n)
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
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        byte n = byte.Parse(Console.ReadLine());
        for (byte i = 0; i < n; i++)
        {
            Console.Write(fibonacci(i));
            if (i<n-1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
       }
    }

