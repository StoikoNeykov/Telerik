using System;

class OnesAndZeros
{
    static void Main()
    {
        // input
        long num = long.Parse(Console.ReadLine());
        if (num <0)
        {
            num =-num;
        }
        string[,] bits = new string[2, 5];
        bits[0, 0] = "###";
        bits[0, 1] = "#.#";
        bits[0, 2] = "#.#";
        bits[0, 3] = "#.#";
        bits[0, 4] = "###";

        bits[1, 0] = ".#.";
        bits[1, 1] = "##.";
        bits[1, 2] = ".#.";
        bits[1, 3] = ".#.";
        bits[1, 4] = "###";
        string asText = Convert.ToString(num, 2).PadLeft(32, '0');
        for (int i = 0; i < 5; i++)
        {
            for (int j = 16; j < 32; j++)
            {
                Console.Write(bits[asText[j] - '0', i]);
                if (j<31)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}

