using System;

class PrimeNumbers
{
    static void Main()
    {
        uint size = uint.Parse(Console.ReadLine());
        var arr = new int[size+1];
        for (int i = 0; i < size+1; i++)
        {
            arr[i] = i;
        }
        arr[1] = 0;
        uint count = 2;
        while (count!=size+1)
        {
            if (arr[count]==0)
            {
                count++;
                continue;
            }
            else if (count*count>size)
            {
                break;
            }
            else
            {
                for (ulong i = count*count; i <= size; i+=count)
                {
                    arr[i] = 0;
                }
                count++;
            }
        }
        int result =0;
        for (uint i = size; i > 0; i--)
        {
            if (arr[i]!=0)
            {
                result = arr[i];
                break;
            }
        }
        Console.WriteLine(result);
    }
}

