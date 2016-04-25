using System;
using System.Globalization;
using System.Threading;

    class BonusScore
    {
        static void Main()
        {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int num = int.Parse(Console.ReadLine());
        switch (num)
        {
            case 1:
            case 2:
            case 3: num *= 10; break;
            case 4:
            case 5:
            case 6: num *= 100; break;
            case 7:
            case 8:
            case 9: num *= 1000;break;
            default: num = 0;break;
        }
        if(num!=0)
        {
            Console.WriteLine(num);
        }
        else
        {
            Console.WriteLine("invalid score");
        }
    }
    }

