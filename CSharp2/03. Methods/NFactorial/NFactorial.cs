using System;
using System.Numerics;

class NFactorial
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        FactorialCall(number);
    }
    static void FactorialCall(int number)
    {
        BigInteger result = 1;

        for (int i = 1; i < number + 1; i++)
        {
            result *= i;
        }
        Console.WriteLine(result);

    }
}

