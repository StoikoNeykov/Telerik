using System;
using System.Globalization;
using System.Threading;

    class Testing
    {
        static void Main()
        {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double d = 43.5;
        long a =BitConverter.DoubleToInt64Bits(d);
        a = a << 63;
        Console.WriteLine(Convert.ToString(a,2));
        }
    }

