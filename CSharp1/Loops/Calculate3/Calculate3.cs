using System;
using System.Globalization;
using System.Threading;
using System.Numerics;

class Calculate3
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int b = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());
        BigInteger facOut = 1; //Factorial out of ()
        BigInteger facIn = 1;   //Factorial inside ()
        for (int i = s + 1; i <= b; i++)
        {
            facOut *= i;
        }
        for (int j = 1; j <= b - s; j++)
        {
            facIn *= j;
        }
        Console.WriteLine(facOut / facIn);
    }
}
