using System;
using System.Linq;

class FirstLargerThanNeighbours
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
        int result = -1;
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                result = i;
                break;
            }
        }
        return result;
    }
}

