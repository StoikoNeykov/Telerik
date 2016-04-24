using System;

    class ThirdDigit
    {
        static void Main()
        {
        int num = int.Parse(Console.ReadLine());
        int ThirdDigit = (num % 1000)/100;
        Console.WriteLine((ThirdDigit==7) ? "true" : "false " + ThirdDigit);
        }
    }

