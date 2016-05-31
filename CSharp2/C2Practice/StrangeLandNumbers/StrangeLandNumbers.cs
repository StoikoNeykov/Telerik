namespace C2Practice
{
    /// <summary>
    /// Program convert some strange numeral system with base 7 to decimal
    /// </summary>
    using System;
    using System.Linq;
    using System.Numerics;

    public class StrangeLandNumbers
    {
        public static string numbers = "fbomlph";
        // its actually: f, bIN, oBJEC, mNTRAVL, lPVKNQ, pNWE, hT. 
        public static void Main()
        {
            var input = Console.ReadLine()
                .Where(char.IsLower)
                .ToArray();
            Console.WriteLine(AnyToDec(new string(input),7));
        }

        public static BigInteger AnyToDec(string anyNumber, int srcSystem)
        {
            BigInteger result = 0;
            foreach (var symbol in anyNumber)
            {
                result = numbers.IndexOf(symbol) + result * srcSystem;
            }
            return result;
        }
    }
}


