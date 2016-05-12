using System;
using System.Text;

class DecimalTohexadecimal
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        bool negative = false;
        if (number < 0)
        {
            negative = true;
            number = -number;
        }
        string result = DecimalToAny(16, number);
        Console.WriteLine(negative ? "-" + result : result);
    }
    static string DecimalToAny(int endSystem, long number)
    {
        string result = string.Empty;
        var builder = new StringBuilder();
        while (number > 0)
        {
            long digit = number % endSystem;
            if (digit <= 9)
            {
                builder.Insert(0, (char)(digit + '0'));
            }
            else if (digit > 9)
            {
                builder.Insert(0, (char)(digit - 10 + 'A'));
            }
            number /= endSystem;
        }
        result = builder.ToString();
        return result;
    }
}