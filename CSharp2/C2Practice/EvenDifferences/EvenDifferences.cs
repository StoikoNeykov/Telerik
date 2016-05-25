using System;
using System.Linq;
using System.Numerics;

class EvenDifferences
{
    static void Main()
    {
        string text = Console.ReadLine();
        var arr = text
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();
        int curentIndex = 1;
        BigInteger evenSum = 0;
        while (curentIndex < arr.Length)
        {
            long curentAbsolute = Math.Abs(arr[curentIndex] - arr[curentIndex - 1]);
            if (curentAbsolute % 2 == 0)
            {
                evenSum += curentAbsolute;
                curentIndex++;
            }
            curentAbsolute = 0;
            curentIndex++;
        }
        Console.WriteLine(evenSum);
    }
}

