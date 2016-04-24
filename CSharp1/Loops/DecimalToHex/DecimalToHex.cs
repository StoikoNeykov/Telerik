using System;

class DecimalToHex
{
    static void Main()
    {
        Int64 num = Int64.Parse(Console.ReadLine());
        string result = null;
        while (num != 0)
        {
            Int64 temp = num % 16;
            switch (temp)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9: result += temp; break;
                case 10: result += 'A'; break;
                case 11: result += 'B'; break;
                case 12: result += 'C'; break;
                case 13: result += 'D'; break;
                case 14: result += 'E'; break;
                case 15: result += 'F'; break;
                default:
                    break;
            }
            num /= 16;

        }
        char[] bits = result.ToCharArray();
        Array.Reverse(bits);
        result = new string(bits);
        Console.WriteLine(result);
    }
}

