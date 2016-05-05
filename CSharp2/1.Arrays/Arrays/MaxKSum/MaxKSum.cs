using System;

class MaxKSum
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        var arr = new int[num];
        int k = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arr);
        int sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += arr[num-i-1];
        }
        Console.WriteLine(sum);
    }
}

