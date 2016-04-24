using System;
using System.Numerics;

class SaddyKopper
{
    static void Main()
    {
        string input = Console.ReadLine();
        int counter = 0;
        while (input.Length > 1 && counter < 10)
        {
            BigInteger sums = 1;

            while (input.Length > 0)
            {
                input = input.Substring(0, input.Length - 1);
                int curentSum = 0;
                for (int i = 0; i < input.Length; i += 2)
                {
                    curentSum += (input[i] - '0');
                }
                sums *= curentSum != 0 ? curentSum : 1;
            }
            input = sums.ToString();
            counter++;
        }
        if (counter < 10)
        {
            Console.WriteLine(counter);
        }
        Console.WriteLine(input);
    }
}