using System;

class MaximalSequence
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        var arr = new int[num];
        int max = 0;
        int curent = 0;
        for (int i = 0; i < num; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
            if (i != 0 && (arr[i] == arr[i - 1]))
            {
                curent++;
            }
            else
            {
                curent = 1;
            }
            if (curent>max)
            {
                max = curent;
            }
        }
        Console.WriteLine(max);
    }
}

