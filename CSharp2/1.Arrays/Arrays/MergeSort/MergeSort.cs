using System;

class MergeSort
{
    static void Merge(int[] arr, int min, int max)
    {
        if (min < max)
        {
            int mid = (min + max) / 2;

            Merge(arr, min, mid);
            Merge(arr, mid + 1, max);

            int[] leftArr = new int[mid - min + 1];
            int[] rightArr = new int[max - mid];
            Array.Copy(arr, min, leftArr, 0, mid - min + 1);
            Array.Copy(arr, mid + 1, rightArr, 0, max - mid);
            int i = 0;
            int j = 0;
            for (int k = min; k < max + 1; k++)
            {
                if (i == leftArr.Length)
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                else if (j == rightArr.Length)
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else if (leftArr[i] <= rightArr[j])
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
            }
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
        Merge(arr, 0, arr.Length-1);
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}

