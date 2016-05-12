using System;

class SayHello
{
    static void Main()
    {
        Hello();
    }
    static void Hello()
    {
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!", name);
    }
}

