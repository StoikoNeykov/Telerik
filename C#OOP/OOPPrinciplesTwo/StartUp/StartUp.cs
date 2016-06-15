namespace StartUp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    using Shapes.Models;
    using Bank.Models;
    using RangeException;

    public static class StartUp
    {
        public static void Main()
        {
            // MakeMeSomeShapesPls(25);

            // TestingShapes();

            // TestBank();

            // TestException();

            // TestExceptionAgain();
        }

        public static void TestingShapes()
        {
            var tri = new Triangle(5, 8);
            Console.WriteLine(tri.CalculateSurface());

            var sqr = new Square(2);
            Console.WriteLine(sqr.CalculateSurface());

            var collection = GetCollection();

            var result = Shape.CollectionSurface(collection);
            Console.WriteLine(result);
        }

        public static void TestBank()
        {
            var pesho = new Individual("Pesho");
            var peshoOffhore = new Company("PeshoOffshore");
            var depo = new DepositAccount(1000, pesho, 5);
            var loan = new LoanAccount(-200, peshoOffhore, 6);
            var mort = new MortgageAccount(200, pesho, 4);

            Console.WriteLine(depo);
            Console.WriteLine(loan);
            Console.WriteLine(mort);
            Console.WriteLine(loan.CalculateInterestRate(32));
            Console.WriteLine(loan.CalculateInterestRate(1));
        }

        public static void TestException()
        {
            var curent = DateTime.Now;
            CultureInfo provider = CultureInfo.InvariantCulture;
            var start = DateTime.ParseExact("01.01.1980", "dd.MM.yyyy", provider);
            var end = DateTime.ParseExact("31.12.2013", "dd.MM.yyyy", provider);
            if (curent < start || curent > end)
            {
                throw new InvalidRangeExeption<DateTime>(start, end, "Take that exception!");
            }
        }

        // coz out of names 
        public static void TestExceptionAgain()
        {
            var num = -5;
            var start = 1;
            var end = 100;

            if (num < start || num > end)
            {
                throw new InvalidRangeExeption<int>(start, end, "Take that exception!");
            }
        }

        // data generators
        public static IEnumerable<Shape> GetCollection()
        {
            var result = new List<Shape>();

            result.Add(new Triangle(2, 6));
            result.Add(new Triangle(17, 17));
            result.Add(new Rectangle(4, 15));
            result.Add(new Square(12));
            result.Add(new Triangle(17, 3));
            result.Add(new Rectangle(10, 2));
            result.Add(new Triangle(14, 6));
            result.Add(new Rectangle(10, 16));
            result.Add(new Square(11));
            result.Add(new Square(11));
            result.Add(new Square(14));
            result.Add(new Rectangle(3, 6));
            result.Add(new Rectangle(10, 15));
            result.Add(new Triangle(7, 11));
            result.Add(new Square(9));
            result.Add(new Square(10));
            result.Add(new Square(19));
            result.Add(new Square(4));
            result.Add(new Rectangle(14, 7));
            result.Add(new Rectangle(1, 5));
            result.Add(new Square(14));
            result.Add(new Rectangle(14, 7));
            result.Add(new Rectangle(13, 2));
            result.Add(new Triangle(18, 11));
            result.Add(new Triangle(13, 7));

            return result;
        }

        public static void MakeMeSomeShapesPls(int size)
        {
            var builder = new StringBuilder();
            var arr = new[] { "Triangle", "Rectangle", "Square" };
            Random rng = new Random();
            for (int i = 0; i < size; i++)
            {
                var ran = rng.Next(3);
                if (ran == 2)
                {
                    Console.WriteLine("result.Add(new {0}({1}));", arr[ran], rng.Next(20) + 1);
                }
                else
                {
                    Console.WriteLine("result.Add(new {0}({1}, {2}));", arr[ran], rng.Next(20) + 1, rng.Next(20) + 1);
                }
            }
        }

    }
}
