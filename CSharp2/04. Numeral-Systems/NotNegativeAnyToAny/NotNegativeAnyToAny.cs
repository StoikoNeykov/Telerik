using System;
using System.Text;
class NotNegativeAnyToAny
{
    static void Main()
    {
        ulong srcSystem = ulong.Parse(Console.ReadLine());
        string number = Console.ReadLine().ToUpper();
        ulong endSystem = ulong.Parse(Console.ReadLine());
        ulong result = AnyToDecimal(srcSystem, number);
        number = DecimalToAny(endSystem, result);
        while (number[0] == 0 && number.Length > 1)
        {
            number = number.Remove(0, 1);
        }
        Console.WriteLine(number);
    }
    static ulong AnyToDecimal(ulong srcSystem, string number)
    {

        ulong result = 0;
        ulong digit = 0;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] >= '0' && number[i] <= '9')
            {
                digit = (ulong)(number[i] - '0');
            }
            else if (number[i] >= 'A' && number[i] <= 'Z')
            {
                digit = (ulong)(number[i] + 10 - 'A');
            }
            result += digit * Pow(srcSystem, number.Length - 1 - i);
        }

        return result;
    }
    static string DecimalToAny(ulong endSystem, ulong number)
    {
        string result = string.Empty;
        var builder = new StringBuilder();
        while (number > 0)
        {
            ulong digit = number % endSystem;
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
        return result==string.Empty? "0":result;
    }
    static ulong Pow(ulong srcSystem, int pow)
    {
        ulong result = 1;
        for (int i = 0; i < pow; i++)
        {
            result *= srcSystem;
        }
        return result;
    }
}



