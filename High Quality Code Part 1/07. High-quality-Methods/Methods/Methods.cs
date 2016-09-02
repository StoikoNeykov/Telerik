using System;

namespace Methods
{
    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, OutoutFormatType.FixedPoint);
            PrintAsNumber(0.75, OutoutFormatType.Percent);
            PrintAsNumber(2.30, OutoutFormatType.RoundTrip);

            double firstPointX = 3;
            double firstPointY = -1;
            double secondPointX = 3;
            double secondPointY = 2.5;

            Console.WriteLine(CalcDistance(firstPointX,
                                            firstPointY,
                                            secondPointX,
                                            secondPointY));

            // not coz I see any reason to be made but have it so i`ll keep it
            Console.WriteLine("Horizontal? " + (firstPointY == secondPointY));
            Console.WriteLine("Vertical? " + (firstPointX == secondPointX));

            Student peter = new Student("Peter", "Ivanov", "17.03.1992", "From Sofia");
            Student stella = new Student("Stella", "Markova", "03.11.1993", "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}",
                                    peter.FirstName,
                                    stella.FirstName,
                                    peter.IsOlderThan(stella));

        }

        static double CalcTriangleArea(double a, double b, double c)
        {
            bool isValid = IsValidTriangle(a, b, c);
            if (!isValid)
            {
                throw new ArgumentException(string.Format(GlobalConstants.InvalidParameterError,
                                                            "triangle sides"));
            }

            double halfPeremeter = (a + b + c) / 2.0;
            double area = Math.Sqrt(halfPeremeter * (halfPeremeter - a) * (halfPeremeter - b) * (halfPeremeter - c));
            return area;
        }

        static string NumberToDigit(int digit)
        {
            var digitsAsStrings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            if (0 <= digit && digit >= 9)
            {
                return digitsAsStrings[digit];
            }
            else
            {
                throw new ArgumentOutOfRangeException(GlobalConstants.IsNotDigitError);
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException(string.Format(GlobalConstants.IsNullOrEmptyError,
                                                            "Array of elements"));
            }

            int max = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        static void PrintAsNumber(object number, OutoutFormatType format)
        {
            switch (format)
            {
                case OutoutFormatType.FixedPoint:
                    {
                        Console.WriteLine("{0:f2}", number);
                        break;
                    }
                case OutoutFormatType.Percent:
                    {
                        Console.WriteLine("{0:p0}", number);
                        break;
                    }
                case OutoutFormatType.RoundTrip:
                    {
                        Console.WriteLine("{0,8}", number);
                        break;
                    }
                default:
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidParameterError,
                                                                "format"));
            }
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        private static bool IsValidTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException(string.Format(GlobalConstants.CannotBeNegativeOrZeroError,
                                                                    "Triangle side"));
            }

            double longerSide = a;
            if (b > longerSide)
            {
                longerSide = b;
            }

            if (c > longerSide)
            {
                longerSide = c;
            }

            return longerSide < (a + b + c - longerSide);
        }
    }
}
