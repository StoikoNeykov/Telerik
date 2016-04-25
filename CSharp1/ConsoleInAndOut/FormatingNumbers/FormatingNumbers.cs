using System;
using System.Globalization;
using System.Threading;
    class FormatingNumbers
    {
        static void Main()
        {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        short numA = short.Parse(Console.ReadLine());
        double numB = double.Parse(Console.ReadLine());
        double numC = double.Parse(Console.ReadLine());
        Console.WriteLine("{0,-10} | {1,10:D10} | {2,10:0.00} | {3,-10:0.000}"
            ,Convert.ToString(numA,16),Convert.ToString(numA,2).PadLeft(10,'0'),numB,numC
            );
        }
    }

