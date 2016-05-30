namespace ConditionalStatements
{
    /// <summary>
    /// Program parse diferent types
    /// </summary>
    using System;
    using System.Globalization;
    using System.Threading;

    public class IntDoubleString
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string size = Console.ReadLine();
            switch (size)
            {
                case "integer":
                    {
                        int num = int.Parse(Console.ReadLine());
                        Console.WriteLine(num + 1);
                        break;
                    }
                case "real":
                    {
                        double num = double.Parse(Console.ReadLine());
                        Console.WriteLine("{0:f2}", num + 1);
                        break;
                    }
                case "text":
                    {
                        string num = Console.ReadLine();
                        Console.WriteLine(num + "*");
                        break;
                    }
                default:
                    Console.WriteLine("invalid format");
                    break;
            }
        }
    }
}