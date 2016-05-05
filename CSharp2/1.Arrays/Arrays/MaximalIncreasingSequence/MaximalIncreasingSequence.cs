using System;

class MaximalIncreasingSequence
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        var arr = new int[num];
        arr[0] = int.Parse(Console.ReadLine());
        int starter = arr[0];
        int curent = 1;
        int max = 0;
        for (int i = 1; i < num; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
            if (i != 0 && arr[i] > starter)
            {
                curent++;
            }
            else
            {
                if (curent > max)
                {
                    max = curent;
                }
                starter = arr[i];
                curent = 1;
            }

        }
        if (curent > max)
        {
            max = curent;
        }
        Console.WriteLine(max);
    }
}

