using System;

namespace Task3
{
    public class Startup
    {
        public static void Main()
        {
            var m = 5;
            var k = 3;

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
                if (actualString.Contains((i + 1).ToString()))
                {
                    continue;
                }

                Rec(maxNumber, maxLenght, actualString + (i + 1));
            }
        }
    }
}