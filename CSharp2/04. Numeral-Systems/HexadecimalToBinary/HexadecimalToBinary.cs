using System;
using System.Linq;
using System.Text;
class HexadecimalToBinary
{
    static void Main()
    {
        string number = Console.ReadLine();
        bool negative = false;
        if (number[0] == '-')
        {
            negative = true;
            var temp = number
                .Where(z => z != '-')
                .ToArray();
            number = new string(temp);
        }
        while (number[0] == 0 && number.Length > 1)
        {
            number = number.Remove(0, 1);
        }
        long result = AnyToDecimal(16, number);
        number = DecimalToAny(2, result);
        while (number[0] == 0 && number.Length > 1)
        {
            number = number.Remove(0, 1);
        }
        Console.WriteLine(negative ? "-" + number : number);
    }
    static long AnyToDecimal(int srcSystem, string number)
    {

        long result = 0;
        int digit = 0;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] >= '0' && number[i] <= '9')
            {
                digit = number[i] - '0';
            }
            else if (number[i] >= 'A' && number[i] <= 'Z')
            {
                digit = number[i] + 10 - 'A';
            }
            result += digit * (long)Math.Pow(srcSystem, number.Length - 1 - i);
        }

        return result;
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
