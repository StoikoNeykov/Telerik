using System;
using System.Collections.Generic;

class DeCatCoding
{
    static string numbers = "abcdefghijklmnopqrstuvwxyz";
    static void Main()
    {
        string text = Console.ReadLine();
        var output = new List<string>();
        var arr = text
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < arr.Length; i++)
        {
            long decNumber = AnyToDec(arr[i], 21);
            text = DecToAny(decNumber, 26);
            Console.Write(text);
            if (i != arr.Length - 1)
            {
                Console.Write(" ");
            }
        }
    }
    static long AnyToDec(string anyNumber, int srcSystem)
    {
        long result = 0;
        foreach (var symbol in anyNumber)
        {
            result = numbers.IndexOf(symbol) + result * srcSystem;
        }
        return result;
    }
    static string DecToAny(long decNumber, int endSystem)
    {
        string result = string.Empty;
        while (decNumber != 0)
        {
            int digitIndex = (int)(decNumber % endSystem);
            char digit = numbers[digitIndex];
            result = digit + result;
            decNumber /= endSystem;
        }
        return result;
    }
}


