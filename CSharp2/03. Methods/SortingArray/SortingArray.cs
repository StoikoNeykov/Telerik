using System;
using System.Linq;

class SortingArray
{
    static void Main()
    {
        
        int size = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        var arr = text
            .Split(new[] {' '} , StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        Sorter(arr);

    }
    static void Sorter(int []arr)
    {
        arr = arr.OrderBy(z=>z).ToArray();
        var result =String.Join(" ", arr);
        Console.WriteLine(result);
    }
}

