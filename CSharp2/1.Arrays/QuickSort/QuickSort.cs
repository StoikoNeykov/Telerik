using System;

class QuickSort
{
    private static void Quick(int[] arr, int min, int max)
    {
        int pivot;

        if (min < max)
        {
            pivot = Partition(arr, min, max);

            if (pivot > 1)
            {
                Quick(arr, min, pivot - 1);
            }
            if (pivot + 1 < max)
            {
                Quick(arr, pivot + 1, max);
            }
        }
    }

    private static int Partition(int[] arr, int min, int max)
    {
        int pivot = arr[min];

        while (true)
        {
            while (arr[min] < pivot) min++;
            while (arr[max] > pivot) max--;

            if (arr[max] == arr[min] && arr[min] == pivot)
                min++;

            if (min < max)
            {
                arr[min] ^= arr[max];
                arr[max] ^= arr[min];
                arr[min] ^= arr[max];
            }
            else
                return max;
        }
    }

    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        var arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Quick(arr, 0, size - 1);
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}

