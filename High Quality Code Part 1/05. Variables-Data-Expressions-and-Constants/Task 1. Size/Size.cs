using System;

namespace TaskSize
{
    public class Size
    {
        private double width;
        private double height;

        public Size(double w, double h)
        {
            this.width = w;
            this.height = h;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be negative or zero!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be negative or zero!");
                }

                this.height = value;
            }
        }

        public static Size GetRotatedSize(
            Size s, double angleOfRotation)
        {
            double newWidth = Math.Abs(Math.Cos(angleOfRotation)) * s.width +
                    Math.Abs(Math.Sin(angleOfRotation)) * s.height;

            double newHeight = Math.Abs(Math.Sin(angleOfRotation)) * s.width +
                    Math.Abs(Math.Cos(angleOfRotation)) * s.height;

            return new Size(newWidth, newHeight);
        }
    }
}
