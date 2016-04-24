using System;

class DivideBy7And5
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        bool isTrue = ( (num%5 == 0) && (num%7==0) ? true : false);
        Console.WriteLine(isTrue ?  "true " + num : "false "+ num);
    }
}
