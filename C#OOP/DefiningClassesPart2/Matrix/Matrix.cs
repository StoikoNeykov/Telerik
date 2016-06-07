namespace Matrix
{
    using System;

    public class Matrix<T> where T : struct, IComparable

    {
        private T[,] matrix;

        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
        }

        public Matrix(T[,] input)
        {
            int rows = input.GetLength(0);
            int cols = input.GetLength(1);
            this.matrix = new T[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.matrix[i, j] = input[i, j];
                }
            }
        }

        public T this[int row, int col]
        {
            get
            {
                this.OutOfRangeCheck(row, col);
                return matrix[row, col];
            }
            set
            {
                this.OutOfRangeCheck(row, col);
                this.matrix[row, col] = value;
            }
        }

        public int Rows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        public void OutOfRangeCheck(int row, int col)
        {
            if (row < 0 || col < 0 || row > matrix.GetLength(0) - 1 || col > matrix.GetLength(1) - 1)
            {
                throw new IndexOutOfRangeException("Index Out Of Range!");
            }
        }

        public void TypeCheck()
        {
            if (typeof(T) != typeof(int) && typeof(T) != typeof(long) && typeof(T) != typeof(short) && typeof(T) != typeof(float) &&
                typeof(T) != typeof(double) && typeof(T) != typeof(decimal))
            {
                throw new ArgumentException("Cannot apply this operator on this type of matrix!");
            }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            m1.TypeCheck();
            m2.TypeCheck();
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
            {
                throw new ArgumentException("Cannot addition matrices with diferent sizes!");
            }

            var result = new Matrix<T>(m1.Rows, m1.Cols);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    result[i, j] = (dynamic) m1[i, j] + m2[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            m1.TypeCheck();
            m2.TypeCheck();
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
            {
                throw new ArgumentException("Cannot substract matrices with diferent sizes!");
            }

            var result = new Matrix<T>(m1.Rows, m1.Cols);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    result[i, j] = (dynamic)m1[i, j] - m2[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            m1.TypeCheck();
            m2.TypeCheck();
        }
    }
}
