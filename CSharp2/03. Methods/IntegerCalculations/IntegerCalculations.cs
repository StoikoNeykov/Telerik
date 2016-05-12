using System;
using System.Linq;

class IntegerCalculations
{
    static void Main()
    {
        string text = Console.ReadLine();
        var numbers = text
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        MinOfFive(numbers);
        MaxOfFive(numbers);
        AvrOfFive(numbers);
        SumOfFive(numbers);
        ProductOfFive(numbers);
    }
    static void MinOfFive (int[] numbers)
    {
        Console.WriteLine(numbers.Min());
    }
    static void MaxOfFive(int[] numbers)
    {
        Console.WriteLine(numbers.Max());
    }
    static void AvrOfFive(int[] numbers)
    {
        Console.WriteLine("{0:f2}", numbers.Average());
    }
    static void SumOfFive(int[] numbers)
    {
        Console.WriteLine(numbers.Sum());
    }
    static void ProductOfFive(int[] numbers)
    {
        long product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        Console.WriteLine(product);
    }
}

