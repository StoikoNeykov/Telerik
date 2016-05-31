namespace C2Practice
{

    /// <summary>
    /// In circular path 2 girls pick flowers and program calc result 
    /// </summary>
    using System;
    using System.Numerics;
    using System.Linq;

    public class TwoGirlsOnePath
    {
        public static void Main()
        {
            var path = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            int last = path.Length - 1;
            BigInteger mollyScore = 0;
            BigInteger dollyScore = 0;
            long mollyPos = 0;
            long dollyPos = last;
            long mollyMove = 0;
            long dollyMove = 0;
            while (true)
            {
                // update score
                if (dollyPos == mollyPos)
                {
                    mollyScore += path[mollyPos] / 2;
                    dollyScore += path[dollyPos] / 2;
                    dollyMove = path[mollyPos];
                    mollyMove = path[mollyPos];
                }
                else
                {
                    mollyScore += path[mollyPos];
                    mollyMove = path[mollyPos];
                    dollyScore += path[dollyPos];
                    dollyMove = path[dollyPos];
                }

                // empty cell checks
                if (path[mollyPos] == 0)
                {
                    if (path[dollyPos] == 0)
                    {
                        Console.WriteLine("Draw");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Dolly");
                        break;
                    }
                }
                else if (path[dollyPos] == 0)
                {
                    Console.WriteLine("Molly");
                    break;
                }

                //update path
                if (dollyPos == mollyPos)
                {
                    path[mollyPos] %= 2;
                }
                else
                {
                    path[mollyPos] = 0;
                    path[dollyPos] = 0;
                }

                // moving
                mollyMove %= last + 1;
                dollyMove %= last + 1;
                mollyPos = mollyPos + mollyMove;
                while (mollyPos > last)
                {
                    mollyPos -= last + 1;
                }

                dollyPos = dollyPos - dollyMove;
                while (dollyPos < 0)
                {
                    dollyPos += last + 1;
                }
            }

            Console.WriteLine("{0} {1}", mollyScore, dollyScore);
        }
    }
}
