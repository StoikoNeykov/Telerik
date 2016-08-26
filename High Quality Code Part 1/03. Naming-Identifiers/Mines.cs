using System;
using System.Collections.Generic;

namespace Mines
{
    public class Mines
    {
        public class Score
        {
            string name;
            int result;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Result
            {
                get { return result; }
                set { result = value; }
            }

            public Score() { }

            public Score(string name, int result)
            {
                this.name = name;
                this.result = result;
            }
        }

        static void Main()
        {
            string command = string.Empty;
            char[,] gamefield = CreateGameField();
            char[,] boms = SetBombs();
            int counter = 0;
            bool isFailed = false;
            List<Score> champions = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool isGameStart = true;
            const int maks = 35;
            bool isComplete = false;

            do
            {
                if (isGameStart)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawGameField(gamefield);
                    isGameStart = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= gamefield.GetLength(0) && col <= gamefield.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        TopScores(champions);
                        break;
                    case "restart":
                        gamefield = CreateGameField();
                        boms = SetBombs();
                        DrawGameField(gamefield);
                        isFailed = false;
                        isGameStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (boms[row, col] != '*')
                        {
                            if (boms[row, col] == '-')
                            {
                                MakeTurn(gamefield, boms, row, col);
                                counter++;
                            }
                            if (maks == counter)
                            {
                                isComplete = true;
                            }
                            else
                            {
                                DrawGameField(gamefield);
                            }
                        }
                        else
                        {
                            isFailed = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isFailed)
                {
                    DrawGameField(boms);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", counter);
                    string name = Console.ReadLine();
                    Score curentScore = new Score(name, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(curentScore);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Result < curentScore.Result)
                            {
                                champions.Insert(i, curentScore);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Score first, Score second) => second.Name.CompareTo(first.Name));
                    champions.Sort((Score first, Score second) => second.Result.CompareTo(first.Result));
                    TopScores(champions);

                    gamefield = CreateGameField();
                    boms = SetBombs();
                    counter = 0;
                    isFailed = false;
                    isGameStart = true;
                }

                if (isComplete)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawGameField(boms);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Score curentScore = new Score(name, counter);
                    champions.Add(curentScore);
                    TopScores(champions);
                    gamefield = CreateGameField();
                    boms = SetBombs();
                    counter = 0;
                    isComplete = false;
                    isGameStart = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void TopScores(List<Score> results)
        {
            Console.WriteLine("\nTo4KI:");
            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, results[i].Name, results[i].Result);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MakeTurn(char[,] gameField, char[,] bombs, int row, int col)
        {
            char bombsCount = ScoreCounter(bombs, row, col);
            bombs[row, col] = bombsCount;
            gameField[row, col] = bombsCount;
        }

        private static void DrawGameField(char[,] gameField)
        {
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", gameField[row, col]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    gameField[row, col] = '?';
                }
            }

            return gameField;
        }

        private static char[,] SetBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> listOfRandoms = new List<int>();
            while (listOfRandoms.Count < 15)
            {
                Random rng = new Random();
                int randomNum = rng.Next(50);
                if (!listOfRandoms.Contains(randomNum))
                {
                    listOfRandoms.Add(randomNum);
                }
            }

            foreach (int randomNum in listOfRandoms)
            {
                int col = (randomNum / cols);
                int row = (randomNum % cols);
                if (row == 0 && randomNum != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static void Calculations(char[,] gameField)
        {
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (gameField[row, col] != '*')
                    {
                        gameField[row, col] = ScoreCounter(gameField, row, col);
                    }
                }
            }
        }

        private static char ScoreCounter(char[,] gameField, int curentRow, int curentCol)
        {
            int counter = 0;
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            if (curentRow - 1 >= 0)
            {
                if (gameField[curentRow - 1, curentCol] == '*')
                {
                    counter++;
                }
            }

            if (curentRow + 1 < rows)
            {
                if (gameField[curentRow + 1, curentCol] == '*')
                {
                    counter++;
                }
            }

            if (curentCol - 1 >= 0)
            {
                if (gameField[curentRow, curentCol - 1] == '*')
                {
                    counter++;
                }
            }

            if (curentCol + 1 < cols)
            {
                if (gameField[curentRow, curentCol + 1] == '*')
                {
                    counter++;
                }
            }

            if ((curentRow - 1 >= 0) && (curentCol - 1 >= 0))
            {
                if (gameField[curentRow - 1, curentCol - 1] == '*')
                {
                    counter++;
                }
            }

            if ((curentRow - 1 >= 0) && (curentCol + 1 < cols))
            {
                if (gameField[curentRow - 1, curentCol + 1] == '*')
                {
                    counter++;
                }
            }

            if ((curentRow + 1 < rows) && (curentCol - 1 >= 0))
            {
                if (gameField[curentRow + 1, curentCol - 1] == '*')
                {
                    counter++;
                }
            }

            if ((curentRow + 1 < rows) && (curentCol + 1 < cols))
            {
                if (gameField[curentRow + 1, curentCol + 1] == '*')
                {
                    counter++;
                }
            }
            return char.Parse(counter.ToString());
        }
    }
}
