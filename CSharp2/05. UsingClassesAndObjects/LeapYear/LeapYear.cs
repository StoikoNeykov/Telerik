using System;
class LeapYear
{
    static void Main()
    {
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine(DateTime.IsLeapYear(year)?"Leap":"Common");
    }

}
