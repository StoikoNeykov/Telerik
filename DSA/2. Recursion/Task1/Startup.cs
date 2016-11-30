using System;

namespace Task1
{
    public class Startup
    {
        public static void Main()
        {
            Rec(4);
        }

        public static void Rec(int max, string actualString = "")
        {

            if (actualString.Length >= max)
            {
                Console.WriteLine(actualString);
                return;
            }

            for (int i = 1; i <= max; i++)
            {
                Rec(max, actualString + i);
            }
        }
    }
}
