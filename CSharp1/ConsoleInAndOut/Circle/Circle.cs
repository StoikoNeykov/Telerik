using System;
using System.Globalization;
using System.Threading;

    class Circle
    {
        static void Main()
        {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double r = double.Parse(Console.ReadLine());
        Console.WriteLine("{0:f2} {1:f2}", (2 * Math.PI * r), (Math.PI*r*r));
        }
    }

