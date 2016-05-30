namespace ConditionalStatements
{
    /// <summary>
    /// Switch practice program
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class PlayCard
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string input = Console.ReadLine();
            switch (input)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "J":
                case "Q":
                case "K":
                case "A": Console.WriteLine("yes {0}", input); break;
                default: Console.WriteLine("no {0}", input); break;
            }
        }
    }
}