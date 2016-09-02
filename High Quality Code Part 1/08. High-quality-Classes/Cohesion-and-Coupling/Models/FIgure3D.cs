using System;

namespace CohesionAndCoupling
{
    public class FIgure3D : IFigure3D
    {
        private readonly string NegativeOrZeroParameterError = "{0} cannot be negative or zero!";

        private double width;

        private double height;

        private double depth;

        public FIgure3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(this.NegativeOrZeroParameterError,
                                                                "Width"));
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(this.NegativeOrZeroParameterError,
                                                                "Height"));
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(this.NegativeOrZeroParameterError,
                                                                "Depth"));
                }

                this.depth = value;
            }
        }

        public double Volume
        {
            get
            {
                return this.Width * this.Height * this.Depth;
            }
        }
    }
}
