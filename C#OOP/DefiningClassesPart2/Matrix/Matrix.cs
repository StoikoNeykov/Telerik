namespace Matrix
{
    using System;
    using System.Text;

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
            if (row < 0 || col < 0 || row > this.matrix.GetLength(0) - 1 || col > this.matrix.GetLength(1) - 1)
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
                    result[i, j] = (dynamic)m1[i, j] + m2[i, j];
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
            if (m1.Cols != m2.Rows)
            {
                throw new ArgumentException("Invalid matrices size! The matrices cannot be multiplied!");
            }

            var result = new Matrix<T>(m1.Rows, m2.Cols);
            T sum;
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    sum = (dynamic)0;
                    for (int k = 0; k < m1.Cols; k++)
                    {
                        sum += (dynamic)m1[i, k] * m2[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        private bool ZeroCheck()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (this[i, j] != (dynamic)0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator true(Matrix<T> curentMatrix)
        {
            return curentMatrix.ZeroCheck();
        }

        public static bool operator false(Matrix<T> curentMatrix)
        {
            return curentMatrix.ZeroCheck();
        }

        public static bool operator !(Matrix<T> curentMatrix)
        {
            return !curentMatrix.ZeroCheck();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (j > 0)
                    {
                        result.Append(" ");
                    }
                    result.Append(this[i, j]);
                }
                if (i != this.Rows - 1)
                {
                    result.AppendLine();
                }
            }

            return result.ToString();
        }
    }
}
