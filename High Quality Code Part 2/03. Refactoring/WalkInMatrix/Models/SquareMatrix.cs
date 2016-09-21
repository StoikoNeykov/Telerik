using System;
using System.Text;

namespace GameFifteen.Models
{
    public class SquareMatrix
    {
        private const int MinSize = 1;
        private const int MaxSize = 100;

        private int size;
        private int[,] matrix;

        public SquareMatrix(int size)
        {
            this.Size = size;
            this.matrix = new int[this.Size, this.Size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < MinSize || MaxSize < value)
                {
                    throw new ArgumentOutOfRangeException("Matrix size");
                }

                this.size = value;
            }
        }

        public int[,] Matrix => this.matrix;

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    builder.AppendFormat("{0,-5}", this.matrix[row, col]);
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
