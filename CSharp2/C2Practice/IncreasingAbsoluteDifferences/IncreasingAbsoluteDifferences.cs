using System;
using System.Linq;

class IncreasingAbsoluteDifferences
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string text = Console.ReadLine();
            var arr = text
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            SeqFinder(arr);
        }
    }

    static void SeqFinder(int[] arr)
    {
        var seqArr = new int[arr.Length - 1];
        for (int i = 1; i < arr.Length; i++)
        {
            seqArr[i - 1] = Math.Abs(arr[i] - arr[i - 1]);
        }
        seqChecker(seqArr);
        return;
    }

    static void seqChecker(int[] seqArr)
    {
        for (int i = 1; i < seqArr.Length; i++)
        {
            if (seqArr[i] - seqArr[i - 1] != 0 &&
                seqArr[i] - seqArr[i - 1] != 1)
            {
                Console.WriteLine("False");
                return;
            }
        }
        Console.WriteLine("True");
        return;
    }
}

