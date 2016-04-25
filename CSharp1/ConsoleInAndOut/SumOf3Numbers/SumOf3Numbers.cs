using System;
using System.Globalization;
using System.Threading;

class SumOf3Numbers
    {
        static void Main()
        {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        float sum = 0;
        for (int i = 0; i < 3; i++)
        {
            float num = float.Parse(Console.ReadLine());
            sum += num;
        }
        Console.WriteLine(sum);
    }
    }

