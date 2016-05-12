using System;

class RemoveElements
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        var arr = new int[size];
        var posiblePosition = new int[size]; //max posible depend of numbers before
        for (int i = 0; i < size; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
            posiblePosition[i] = 0; //every number can be start of best line (position 0)
        }
        for (int i = 1; i < size; i++) //every number in arr
        {
            for (int j = 0; j < i; j++) //check numbers before curent
            {
                if (arr[i] >= arr[j] && posiblePosition[i] <= posiblePosition[j])
                {
                    posiblePosition[i] = posiblePosition[j] + 1;
                }
            }
        }
        int max = 0;
        for (int i = 0; i < size; i++)
        {
            if (posiblePosition[i] > max)
            {
                max = posiblePosition[i];
            }
        }
        Console.WriteLine(size - max -1); //-1 coz positions start counting from 0

    }
}


