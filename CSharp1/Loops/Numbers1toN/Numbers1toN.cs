using System;

class Numbers1toN
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        for (int i = 1; i < num + 1; i++)
        {
            Console.Write("{0}", i);
            if (i < num)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}
