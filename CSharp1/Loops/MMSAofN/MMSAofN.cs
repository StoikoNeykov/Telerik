using System;
using System.Globalization;
using System.Threading;

class MMSAofN
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int num = int.Parse(Console.ReadLine());
        double min = 0;
        double max = 0;
        double sum = 0;
        double avg = 0;
        for (int i = 0; i < num; i++)
        {
            double curent = double.Parse(Console.ReadLine());
            if (i == 0)
            {
                min = max = sum = avg = curent;
            }
            else
            {
                if (curent < min)
                {
                    min = curent;
                }
                if (curent > max)
                {
                    max = curent;
                }
                sum += curent;
                avg = sum / (i + 1);

            }
        }
        Console.WriteLine("min={0:f2}", min);
        Console.WriteLine("max={0:f2}", max);
        Console.WriteLine("sum={0:f2}", sum);
        Console.WriteLine("avg={0:f2}", avg);
    }
}
