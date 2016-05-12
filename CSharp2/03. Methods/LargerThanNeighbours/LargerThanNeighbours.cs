using System;
using System.Linq;

class LargerThanNeighbours
{
    static void Main()
    {
        string text = Console.ReadLine();
        text = Console.ReadLine();
        var arr = text
                  .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();
        Console.WriteLine(IndexFinder(arr));
    }
    static int IndexFinder(int[] arr)
    {
        int result = 0;
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                result++;
            }
        }
        return result;
    }
}

