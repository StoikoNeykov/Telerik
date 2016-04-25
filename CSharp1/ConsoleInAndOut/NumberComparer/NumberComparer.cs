using System;
using System.Globalization;
using System.Threading;
    class NumberComparer
    {
        static void Main()
        {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double numA = double.Parse(Console.ReadLine());
        double numB = double.Parse(Console.ReadLine());
        Console.WriteLine("{0}", numA>numB? numA:numB);
        }
    }

