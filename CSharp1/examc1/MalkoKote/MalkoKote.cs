using System;

class MalkoKote
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        char s = Convert.ToChar(Console.ReadLine());
        int x = (num - 6) / 4;
        //line 1
        Console.Write(" ");
        Console.Write(s);
        Console.Write(new string(' ', x));
        Console.Write(s);
        Console.Write(new string(' ', 4 + x));
        Console.WriteLine();
        //head
        for (int i = 0; i < x; i++)
        {
            Console.Write(" ");
            Console.Write(new string(s, x + 2));
            Console.Write(new string(' ', 4 + x));
            Console.WriteLine();
        }
        //neck
        for (int i = 0; i < x; i++)
        {
            Console.Write(new string(' ', 2));
            Console.Write(new string(s, x));
            Console.Write(new string(' ', 5 + x));
            Console.WriteLine();
        }
        //body
        for (int i = 0; i < x + 1; i++)
        {
            Console.Write(" ");
            Console.Write(new string(s, x + 2));
            if (i == x)
            {
                Console.Write(new string(' ', 3));
                Console.Write(new string(s, 1 + x));
            }
            else
            {
                Console.Write(new string(' ', 4 + x));
            }
            Console.WriteLine();

        }
        //ass
        for (int i = 0; i < x + 3; i++)
        {

            Console.Write(new string(s, x + 4));
            if (i == x + 2)
            {
                Console.Write(new string(' ', 1));
                Console.Write(new string(s, 2));
                Console.Write(new string(' ', x));
            }
            else
            {
                Console.Write(new string(' ', 2));
                Console.Write(new string(s, 1));
                Console.Write(new string(' ', x));
            }
            Console.WriteLine();
        }
        //legs
        Console.Write(" ");
        Console.Write(new string(s, x + 5));
        Console.Write(new string(' ', x + 1));
        Console.WriteLine();
    }
}

