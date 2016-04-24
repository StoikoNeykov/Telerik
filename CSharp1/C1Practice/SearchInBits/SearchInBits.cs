using System;

class SearchInBits
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        num = num & 15;
        int counter = 0;
        int numbers = int.Parse(Console.ReadLine());
        for (int i = 0; i < numbers; i++)
        {
            int curent = int.Parse(Console.ReadLine());
            for (int j = 0; j < 27; j++)
            {
                string aaText = Convert.ToString(curent, 2);
                if ((curent & 15) == num)
                {
                    counter++;
                }
                curent = curent >> 1;
            }
        }
        Console.WriteLine(counter);
    }
}

