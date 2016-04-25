using System;
using System.Globalization;
using System.Threading;

    class BiggestOf3
    {
        static void Main()
        {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        if (a > b && a > c)
        {
            Console.WriteLine(a);
        }
        else if (b>c)
        {
            Console.WriteLine(b);
        }
        else
        {
            Console.WriteLine(c);
        }
    }
    }

