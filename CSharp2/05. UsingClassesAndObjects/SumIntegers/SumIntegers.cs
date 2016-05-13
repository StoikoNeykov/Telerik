using System;
using System.Linq;

class SumIntegers
{
    static void Main()
    {
        string text = Console.ReadLine();
        var sum = text
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Sum();
        Console.WriteLine(sum);
    }
}

