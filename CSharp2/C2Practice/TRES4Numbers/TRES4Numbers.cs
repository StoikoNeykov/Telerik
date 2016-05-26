using System;
using System.Collections.Generic;

class TRES4Numbers
{
    static string[] translator = new string[9]
        {   @"LON+",
            @"VK-",
            @"*ACAD",
            @"^MIM",
            @"ERIK|",
            @"SEY&",
            @"EMY>>",
            @"/TEL",
            @"<<DON" };
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        string result = string.Empty;
        if (number == 0)
        {
            result = "LON+";
        }
        else
        {
            result = DecToAny(number, 9);
        }
        Console.WriteLine(result);
    }
    static string DecToAny(ulong decNumber, ulong endSystem)
    {
        string result = string.Empty;
        while (decNumber != 0)
        {
            int digitIndex = (int)(decNumber % endSystem);
            string digit = translator[digitIndex];
            result = digit + result;
            decNumber /= endSystem;
        }
        return result;
    }
}

