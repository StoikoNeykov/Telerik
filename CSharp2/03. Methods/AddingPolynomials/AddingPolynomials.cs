using System;
using System.Linq;

class AddingPolynomials
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine()); //!
        string text = Console.ReadLine();
        var arrOne = text
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        text = Console.ReadLine();
        var arrTwo = text
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        AddPolynomials(arrOne, arrTwo);
    }
    static void AddPolynomials(int[] arrOne, int[] arrTwo)
    {
        for (int i = 0; i < arrOne.Length; i++)
        {
            arrOne[i] += arrTwo[i];
        }
        var result = string.Join(" ", arrOne);
        Console.WriteLine(result);
    }
}

