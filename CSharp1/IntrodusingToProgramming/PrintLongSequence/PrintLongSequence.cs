namespace IntrodusingToPrograming
{
    /// <summary>
    /// Program prints on the console the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7 ... 
    /// </summary>
    using System;

    public class PrintLongSequence
    {
        public static void Main()
        {
            for (int i = 2; i <= 1001; i++)
            {
                if ((i % 2) == 0)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(-i);
                }
            }
        }
    }
}