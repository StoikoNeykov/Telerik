using System;
using System.Globalization;
using System.Threading;

class Calculate
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int num = int.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());
        double sum = 1 + 1 / x;
        int curentFac = 1;
        for (int i = 2; i <= num; i++)
        {
            curentFac *= i;
            double pow = Math.Pow(x, i);
            sum += (curentFac / pow);
        }
        Console.WriteLine("{0:f5}", sum);
    }
}
