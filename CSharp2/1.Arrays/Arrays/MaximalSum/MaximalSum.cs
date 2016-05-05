using System;

class MaximalSum
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        var arr = new int[size];
        int curentSum = 0; //coz max sum if all elements are negative is 0 (substing with size 0)
        int maxSum = 0;    
        for (int i = 0; i < size; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
            curentSum += arr[i];
            if (curentSum>maxSum)
            {
                maxSum = curentSum;
            }
            else if (curentSum<0)
            {
                curentSum = 0;
            }
        }
        Console.WriteLine(maxSum);
    }
}

