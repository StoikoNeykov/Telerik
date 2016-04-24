using System;

class GCD
{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] separator = { ' ' };
        string[] number = input.Split(separator);
        int num1 = int.Parse(number[0]);
        int num2 = int.Parse(number[1]);
        if (num1 < 0)
        {
            num1 = -num1;
        }
        if (num2 < 0)
        {
            num2 = -num2;
        }
        while (num1 != 0 && num2 != 0)
        {
            if (num1 > num2)
            {
                num1 %= num2;
            }
            else
            {
                num2 %= num1;
            }
        }
        Console.WriteLine(Math.Max(num1, num2));
    }
}

