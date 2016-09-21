using System;
using GameFifteen.Extensions;
using GameFifteen.Models;

namespace GameFifteen
{
    public class WalkInMatrica
    {
        public static void Main()
        {
            var size = 7;

            //Console.WriteLine("Enter a positive number ");
            //string input = Console.ReadLine();

            //while (!int.TryParse(input, out size) || size < 0 || size > 100)
            //{
            //    Console.WriteLine("You haven't entered a correct positive number");
            //    input = Console.ReadLine();
            //}

            var matrix = new SquareMatrix(size);

            matrix.Matrix.FillTillGlitch(1);
            Console.WriteLine(matrix);

            matrix.Matrix.FillTillGlitch(matrix.Matrix.GetMax() + 1);
            Console.WriteLine(matrix);

        }
    }
}
