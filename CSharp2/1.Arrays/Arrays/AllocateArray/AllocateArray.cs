using System;

class AllocateArray
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        var arr = new int[num];
        for (int i = 0; i < num; i++)
        {
            arr[i] = i * 5;
            Console.WriteLine(arr[i]);
        }
    }
}

