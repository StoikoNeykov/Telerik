using System;
using System.Linq;

class GetLargestNumber
{
    static void Main()
    {
        string text = Console.ReadLine();
        var arr = text
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int max = int.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            max = GetMax(arr[i], max);
        }
        Console.WriteLine(max);
    }
    static int GetMax(int numOne, int numTwo)
    {
        int max = numOne;
        if (numOne<numTwo)
        {
            max = numTwo;
        }
        return max;
    }
}

