using System;

class SelectionSort
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        var arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        int curent = 0;
        while (curent != size)
        {
            for (int i = curent; i < size; i++)
            {
                if (arr[i] < arr[curent])
                {
                    int temp = arr[i];
                    arr[i] = arr[curent];
                    arr[curent] = temp;
                }
            }
            curent++;
        }
        foreach (var number in arr)
        {
            Console.WriteLine(number);
        }
    }
}

