using System;


class Trailing0inFactorial
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int zeroes = 0;
        int divider = 5;
        while (num/divider>=1)
        {
            zeroes += num / divider;
            divider *= 5;
        }
        
        Console.WriteLine(zeroes);
    }
}

