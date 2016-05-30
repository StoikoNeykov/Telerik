namespace Loops
{
    /// <summary>
    /// Printing cards 
    /// </summary>
    using System;

    public class PrintADeck
    {
        public static void Main()
        {
            string[] all = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string card = Console.ReadLine();
            int i = 0;
            do
            {
                Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", all[i]);
                if (all[i] == card)
                {
                    break;
                }

                i++;
            }
            while (i < all.Length);
        }
    }
}