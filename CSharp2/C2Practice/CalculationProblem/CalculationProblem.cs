using System;
using System.Linq;

class CalculationProblem
{
    static string numbers = "abcdefghijklmnopqrstuvw";
    static void Main()
    {
        string catNumber = Console.ReadLine();
        var arr = catNumber
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        long decSum = 0;
        foreach (var number in arr)
        {
            decSum += AnyToDec(number, 23);
        }
        catNumber = DecToAny(decSum, 23);
        Console.WriteLine("{0} = {1}", catNumber, decSum);
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

