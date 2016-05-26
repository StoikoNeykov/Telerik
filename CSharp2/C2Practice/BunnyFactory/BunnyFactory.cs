using System;
using System.Collections.Generic;
using System.Numerics;

class BunnyFactory
{
    static void Main()
    {
        var cages = new List<int>();
        string input = Console.ReadLine();
        while (input != "END")
        {
            cages.Add(int.Parse(input));
            input = Console.ReadLine();
        }
        bool itsDone = false;
        for (int i = 1; true; i++)
        {
            if (i < cages.Count)
            {

                itsDone = WorkingCyrcle(cages, i);

            }
            else
            {
                break;
            }

            if (itsDone)
            {
                break;
            }
        }
        //output
        var result = string.Join(" ", cages);
        Console.WriteLine(result);

    }

    private static bool WorkingCyrcle(List<int> cages, int i)
    {
        int neededCells = 0;
        for (int j = 0; j < i; j++)
        {
            neededCells += cages[j];
        }
        if (neededCells > cages.Count - i)
        {
            return true;
        }
        BigInteger product = 1;
        int sum = 0;
        for (int j = 0; j < neededCells; j++)
        {
            sum += cages[i + j];
            product *= cages[i + j];
        }
        string result = sum.ToString() + product.ToString();
        for (int j = neededCells + i; j < cages.Count; j++)
        {
            result += cages[j];
        }
        cages.Clear();
        foreach (var symbol in result)
        {
            if (symbol!='0' &&symbol!='1')
            {
                cages.Add(symbol - '0');
            }
        }
        return false;
    }
}

