namespace C2Exam
{
    using System;
    using System.Numerics;

    public class CryptoCS
    {
        public static string texts = "abcdefghijklmnopqrstuvwxyz";
        public static string numbs = "0123456";
        public static string resultnumbers = "012345678";

        public static void Main()
        {
            string textSystem = Console.ReadLine().Trim().ToLower();
            char op = char.Parse(Console.ReadLine().Trim().ToLower());
            string numberSystem = Console.ReadLine().Trim().ToLower();

            BigInteger firstNumber = AnyToDec(textSystem, 26, texts);
            BigInteger secondNumber = AnyToDec(numberSystem, 7, numbs);
            BigInteger result;
            if (op == '+')
            {
                result = firstNumber + secondNumber;
            }
            else
            {
                result = firstNumber - secondNumber;
            }
            Console.WriteLine(DecToAny(result, 9, resultnumbers));
        }

        public static BigInteger AnyToDec(string anyNumber, int srcSystem, string numbers)
        {
            BigInteger result = 0;
            foreach (var symbol in anyNumber)
            {
                result = numbers.IndexOf(symbol) + result * srcSystem;
            }
            return result;
        }

        static string DecToAny(BigInteger decNumber, int endSystem, string numbers)
        {
            string result = string.Empty;
            while (decNumber != 0)
            {
                int digitIndex = (int)(decNumber % endSystem);
                char digit = numbers[digitIndex];
                result = digit + result;
                decNumber /= endSystem;
            }
            return result;
        }
    }
}