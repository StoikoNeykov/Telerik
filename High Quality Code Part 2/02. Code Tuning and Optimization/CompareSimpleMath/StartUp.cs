using System;
using System.Diagnostics;

namespace CompareSimpleMath
{
    public class StartUp
    {
        private const int NumberOfCalls = 10000;

        public static void Main()
        {
            Console.WriteLine("Add:");
            Console.WriteLine($"Int: {Exec<int>((a, b) => (a + b), NumberOfCalls)}");
            Console.WriteLine($"Long: {Exec<long>((a, b) => (a + b), NumberOfCalls)}");
            Console.WriteLine($"Float: {Exec<float>((a, b) => (a + b), NumberOfCalls)}");
            Console.WriteLine($"Double: {Exec<double>((a, b) => (a + b), NumberOfCalls)}");
            Console.WriteLine($"Decimal: {Exec<decimal>((a, b) => (a + b), NumberOfCalls)}");
            Console.WriteLine();

            Console.WriteLine("Substract:");
            Console.WriteLine($"Int: {Exec<int>((a, b) => (a - b), NumberOfCalls)}");
            Console.WriteLine($"Long: {Exec<long>((a, b) => (a - b), NumberOfCalls)}");
            Console.WriteLine($"Float: {Exec<float>((a, b) => (a - b), NumberOfCalls)}");
            Console.WriteLine($"Double: {Exec<double>((a, b) => (a - b), NumberOfCalls)}");
            Console.WriteLine($"Decimal: {Exec<decimal>((a, b) => (a - b), NumberOfCalls)}");
            Console.WriteLine();

            Console.WriteLine("Increment:");
            Console.WriteLine($"Int: {Exec<int>((a, b) => (a++), NumberOfCalls)}");
            Console.WriteLine($"Long: {Exec<long>((a, b) => (a++), NumberOfCalls)}");
            Console.WriteLine($"Float: {Exec<float>((a, b) => (a++), NumberOfCalls)}");
            Console.WriteLine($"Double: {Exec<double>((a, b) => (a++), NumberOfCalls)}");
            Console.WriteLine($"Decimal: {Exec<decimal>((a, b) => (a++), NumberOfCalls)}");
            Console.WriteLine();

            Console.WriteLine("multiply:");
            Console.WriteLine($"Int: {Exec<int>((a, b) => (a * b), NumberOfCalls)}");
            Console.WriteLine($"Long: {Exec<long>((a, b) => (a * b), NumberOfCalls)}");
            Console.WriteLine($"Float: {Exec<float>((a, b) => (a * b), NumberOfCalls)}");
            Console.WriteLine($"Double: {Exec<double>((a, b) => (a * b), NumberOfCalls)}");
            Console.WriteLine($"Decimal: {Exec<decimal>((a, b) => (a * b), NumberOfCalls)}");
            Console.WriteLine();

            // increment b coz cannot divide to 0
            Console.WriteLine("multiply:");
            Console.WriteLine($"Int: {Exec<int>((a, b) => (a / ++b), NumberOfCalls)}");
            Console.WriteLine($"Long: {Exec<long>((a, b) => (a / ++b), NumberOfCalls)}");
            Console.WriteLine($"Float: {Exec<float>((a, b) => (a / ++b), NumberOfCalls)}");
            Console.WriteLine($"Double: {Exec<double>((a, b) => (a / ++b), NumberOfCalls)}");
            Console.WriteLine($"Decimal: {Exec<decimal>((a, b) => (a / ++b), NumberOfCalls)}");
            Console.WriteLine();
        }

        private static TimeSpan Exec<T>(Func<T, T, T> func, int times)
        {
            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < times; i++)
            {
                func(default(T), default(T));
            }

            watch.Stop();
            return watch.Elapsed;
        }
    }
}
