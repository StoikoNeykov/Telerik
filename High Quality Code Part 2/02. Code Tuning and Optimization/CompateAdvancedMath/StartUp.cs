using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompateAdvancedMath
{
    public class StartUp
    {
        private const int NumberOfCalls = 10000;

        public static void Main()
        {
            Console.WriteLine("Square root");
            Console.WriteLine($"Float: {Exec<float>((x) => ((float)Math.Sqrt(x)), NumberOfCalls)}");
            Console.WriteLine($"Double: {Exec<double>((x) => (Math.Sqrt(x)), NumberOfCalls)}");
            Console.WriteLine($"Deciaml: {Exec<decimal>((x) => ((decimal)Math.Sqrt((double)x)), NumberOfCalls)}");
            Console.WriteLine();

            Console.WriteLine("Natural logarithm");
            Console.WriteLine($"Float: {Exec<float>((x) => ((float)Math.Log(++x)), NumberOfCalls)}");
            Console.WriteLine($"Double: {Exec<double>((x) => (Math.Log(++x)), NumberOfCalls)}");
            Console.WriteLine($"Deciaml: {Exec<decimal>((x) => ((decimal)Math.Log((double)++x)), NumberOfCalls)}");
            Console.WriteLine();

            Console.WriteLine("Sinus");
            Console.WriteLine($"Float: {Exec<float>((x) => ((float)Math.Sin(x)), NumberOfCalls)}");
            Console.WriteLine($"Double: {Exec<double>((x) => (Math.Sin(x)), NumberOfCalls)}");
            Console.WriteLine($"Deciaml: {Exec<decimal>((x) => ((decimal)Math.Sin((double)x)), NumberOfCalls)}");
            Console.WriteLine();
        }

        private static TimeSpan Exec<T>(Func<T, T> func, int times)
        {
            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < times; i++)
            {
                func(default(T));
            }

            watch.Stop();
            return watch.Elapsed;
        }
    }
}
