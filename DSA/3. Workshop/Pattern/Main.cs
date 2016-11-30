using System;
using System.Collections.Generic;
using System.Linq;

namespace Pattern
{
    class MainClass
    {
        public static string baseString = "urd";
        public static List<string> collection = new List<string>();

        private static Dictionary<char, char> rotationsRight = new Dictionary<char, char>()
        {
            {'u', 'r' },
            {'r', 'u' },
            {'d', 'l' },
            {'l', 'd' }
        };

        private static Dictionary<char, char> rotationsLeft = new Dictionary<char, char>()
        {
            {'u', 'l' },
            {'r', 'd' },
            {'d', 'r' },
            {'l', 'u' }
        };

        public static void Main()
        {
            collection.Add(baseString);

            var input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                collection.Add(GenerateNextString());
            }

            var figure = collection[input - 1];

            Console.WriteLine(figure);


            // Your solution goes here
            //string figure = "urd";
            //Console.WriteLine(figure);

            // comment before submitting
            // Svg.WriteToFile("output.svg", figure);
        }

        public static string GenerateNextString()
        {
            var last = collection.Last();

            var right = TurnRight(last);
            var left = TurnLeft(last);

            string result = right + "u" + last + "r" + last + "d" + left;

            return result;
        }

        public static string TurnRight(string str)
        {
            var result = str.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                var current = result[i];

                result[i] = rotationsRight[current];
            }

            return new string(result);
        }

        public static string TurnLeft(string str)
        {
            var result = str.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                var current = result[i];

                result[i] = rotationsLeft[current];
            }

            return new string(result);
        }
    }
}
