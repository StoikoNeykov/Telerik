using System;
using System.Globalization;
using System.Threading;

    class Interval
    {
        static void Main()
        {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        short num1 = short.Parse(Console.ReadLine());
        short num2 = short.Parse(Console.ReadLine());
        int count = 0;
        for (int i = num1+1; i < num2; i++)
        {
            if(i % 5 == 0)
            {
                count++;
            }
            
        }
        Console.WriteLine(count);
        }
    }

