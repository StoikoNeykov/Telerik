namespace Shapes.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Parent class for all shapes. Abstract
    /// </summary>
    public abstract class Shape
    {
        private double width;

        private double height;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0 || value == 0)
                {
                    throw new ArgumentException("Cannot be negative or zero!");
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
            private set
            {
                if (value < 0 || value == 0)
                {
                    throw new ArgumentException("Cannot be negative or zero!");
                }

                this.height = value;
            }
        }

        public abstract double CalculateSurface();

        public static double CollectionSurface(IEnumerable<Shape> shapes)
        {
            double result = 0;
            foreach (var shape in shapes)
            {
                result += shape.CalculateSurface();
            }

            return result;
        }
    }
}
