using System;
using System.Linq;

class CompareArrays
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        var arrOne = new int[num];
        var arrTwo = new int[num];
        for (int i = 0; i < num; i++)
        {
            arrOne[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < num; i++)
        {
            arrTwo[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(arrOne.SequenceEqual(arrTwo)?"Equal":"Not equal");
    }
}

