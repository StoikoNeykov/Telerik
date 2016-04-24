

using System;

class AngryFemaleGPS
{
    static void Main()
    {
        long num = long.Parse(Console.ReadLine());
        if (num < 0)
        {
            num = -num;
        }
        long sumEven = 0;
        long sumOdd = 0;
        while (num != 0)
        {
            if (num % 2 == 0)
            {
                sumEven += num % 10;
            }
            else
            {
                sumOdd += num % 10;
            }
            num /= 10;
        }
        if (sumOdd == sumEven)
        {
            Console.WriteLine("straight {0}", sumEven);
        }
        else if (sumEven > sumOdd)
        {
            Console.WriteLine("right {0}", sumEven);
        }
        else
        {
            Console.WriteLine("left {0}", sumOdd);
        }
    }
}



