using System;
using System.Collections.Generic;
using System.Linq;

class FrequentNumber
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        var arr = new int[size];
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < size; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
            if (!dict.ContainsKey(arr[i]))
            {
                dict.Add(arr[i], 0);
            }
            dict[arr[i]]++;
        }
        var result = dict
            .OrderByDescending(z => z.Value)
            .First();
        Console.WriteLine("{0} ({1} times)",result.Key,result.Value);
    }
}

