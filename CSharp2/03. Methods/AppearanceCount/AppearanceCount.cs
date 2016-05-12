using System;
using System.Linq;

class AppearanceCount
{
    static void Main()
    {
        string text = Console.ReadLine();
        text = Console.ReadLine();
        var arr = text
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int needed = int.Parse(Console.ReadLine());
        Console.WriteLine(Finder(arr,needed));
    }
    static int Finder (int[] arr, int needed)
    {
        int count = arr
            .Where(z => z == needed)
            .Count();
        return count;
    }
}
