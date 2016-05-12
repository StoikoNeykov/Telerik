using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string result = ReturnReverse(input);
        Console.WriteLine(result);
    }
    static string ReturnReverse(string text)
    {
        var temp = text
            .ToCharArray();
        Array.Reverse(temp);
        return new string(temp);
    }
}

