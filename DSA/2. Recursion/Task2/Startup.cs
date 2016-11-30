using System;

namespace Task2
{
    public class Startup
    {
        public static void Main()
        {
            var m = 3;
            var k = 4;

            Rec(m, k);
        }

        public static void Rec(int maxNumber, int maxLenght, string actualString = "")
        {
            if (actualString.Length >= maxLenght)
            {
                Console.WriteLine(actualString);
                return;
            }

            for (int i = 0; i < maxNumber; i++)
            {
                Rec(maxNumber, maxLenght, actualString + (i + 1));
            }
        }
    }
}
