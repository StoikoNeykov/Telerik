using System;
using System.Collections.Generic;

class Conductors
{
    static void Main()
    {
        int p = int.Parse(Console.ReadLine());
        int nums = int.Parse(Console.ReadLine());
        int patern = Convert.ToString(p, 2).Length;
        int curent;
        var output = new List<int>();
        for (int i = 0; i < nums; i++)
        {
            curent = int.Parse(Console.ReadLine());
            if (curent >= p)
            {
                for (int j = 0; j < 32 - patern; j++)
                {
                    int temp = curent >> j;
                    temp = temp << 32 - patern;
                    int mask = p << 32 - patern;
                    if (mask == temp)
                    {
                        curent = curent ^ (p << j);
                    }
                }
            }


            output.Add(curent);
        }
        foreach (var item in output)
        {
            Console.WriteLine(item);
        }
    }
}