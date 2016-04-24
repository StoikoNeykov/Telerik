using System;

    class OddOrEven
    {
        static void Main()
        {
        sbyte num = SByte.Parse(Console.ReadLine());
        sbyte mask = 1;
        bool isOdd = ((num & mask)==1 ? true: false);
        Console.WriteLine(isOdd ? "odd " + num : "even " + num);
        }
    }

