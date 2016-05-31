using System;
using System.Globalization;
using System.Threading;

class SumOfEvenDivisors
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        long sum = 0;
        if (a > b) //make sure b is bigger
        {
            int temp = a;
            a = b;
            b = temp;
        }
        for (int i = a; i <= b; i++)
        {
            for (int j = 2; j <= i; j++)
            {
                if ((i % j == 0) && (j % 2 == 0))
                {
                    sum += j;
                }
            }
        }
        Console.WriteLine(sum);
    }
}

