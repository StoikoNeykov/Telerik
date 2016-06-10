namespace Matrix
{
    using System;
    /// <summary>
    /// Tests on matrices
    /// </summary>
    public static class Test
    {
        public static void MatrixTest()
        {
            var firstMatrix = new Matrix<int>(3, 3);
            if (!firstMatrix)
            {
                FillSum(firstMatrix);
            }

            Console.WriteLine(firstMatrix);
            if (firstMatrix)
            {
                Console.WriteLine("First matrix is no longer empty!");
            }

            var addMatrix = new Matrix<int>(3, 3);
            FillOne(addMatrix);


            Console.WriteLine("AddMatrix:");
            Console.WriteLine(addMatrix);

            var addResult = firstMatrix + addMatrix;
            Console.WriteLine();
            Console.WriteLine("Result of add:");
            Console.WriteLine(addResult);

            var secondMatrix = new Matrix<int>(3, 5);
            if (!secondMatrix)
            {
                FillMulty(secondMatrix);
            }

            Console.WriteLine("Second matrix:");
            Console.WriteLine(secondMatrix);

            var multyResult = firstMatrix * secondMatrix;

            Console.WriteLine("Multiplication result:");
            Console.WriteLine(multyResult);
        }

        // filling matrix with 2 for loops: i+j
        public static void FillSum(Matrix<int> curentMatrix)
        {
            for (int i = 0; i < curentMatrix.Rows; i++)
            {
                for (int j = 0; j < curentMatrix.Cols; j++)
                {
                    curentMatrix[i, j] = i + j;
                }
            }
        }

        // filling matrix with 2 for loops: all with 1
        public static void FillOne(Matrix<int> curentMatrix)
        {
            for (int i = 0; i < curentMatrix.Rows; i++)
            {
                for (int j = 0; j < curentMatrix.Cols; j++)
                {
                    curentMatrix[i, j] = 1;
                }
            }
        }

        // filling matrix with 2 for loops: i*j
        public static void FillMulty(Matrix<int> curentMatrix)
        {
            for (int i = 0; i < curentMatrix.Rows; i++)
            {
                for (int j = 0; j < curentMatrix.Cols; j++)
                {
                    curentMatrix[i, j] = i * j;
                }
            }
        }
    }
}
