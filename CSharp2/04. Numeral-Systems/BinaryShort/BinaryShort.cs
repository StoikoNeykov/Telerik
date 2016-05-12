using System;
using System.Text;

class DecimalToBinary
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        if (number < 0)
        {
            var result = Convert.ToString((ushort.MaxValue + number + 1), 2);
            Console.WriteLine(result);
        }
        else
        {
            string result = DecimalToAny(2, number).PadLeft(16, '0');
            Console.WriteLine(result);
        }
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