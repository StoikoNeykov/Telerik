using System;
using System.Linq;

class NumberAsArray
{
    static void Main()
    {
        string text = Console.ReadLine();
        int[] lenghts = StringToIntArr(text);
        int size = lenghts[0] > lenghts[1] ? lenghts[0] : lenghts[1];
        text = Console.ReadLine();
        int[] arrOne = StringToIntArr(text);
        text = Console.ReadLine();
        int[] arrTwo = StringToIntArr(text);
        int[] result = Sum(arrOne, arrTwo, size);
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i]);
            if (i == result.Length - 2 && result[result.Length - 1] == 0)
            {
                break;
            }
            if (i < result.Length - 1)
            {
                Console.Write(' ');
            }
        }
        Console.WriteLine();
    }
    static int[] StringToIntArr(string text)
    {
        var arr = text
                   .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
        return arr;
    }
    static int[] Sum(int[] arrOne, int[] arrTwo, int size)
    {
        var result = new int[size + 1];
        for (int i = 0; i < size; i++)
        {
            int fromOne = 0;
            if (i < arrOne.Length)
            {
                fromOne = arrOne[i];
            }
            int fromTwo = 0;
            if (i < arrTwo.Length)
            {
                fromTwo = arrTwo[i];
            }
            result[i] = fromOne + fromTwo;
        }
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] > 9)
            {
                result[i] -= 10;
                result[i + 1]++;
            }
        }
        return result;
    }
}
