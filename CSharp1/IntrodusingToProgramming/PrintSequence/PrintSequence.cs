namespace IntrodusingToPrograming
{
    /// <summary>
    /// Program print first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
    /// </summary>
    using System;

    public class PrintSequence
    {
        public static void Main()
        {
            for (int i = 2; i <= 11; i++)
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