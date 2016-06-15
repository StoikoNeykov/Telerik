using System;

namespace Shapes.Models
{
    /// <summary>
    /// Represent Rectangle. Implement base`s calculateSurface().
    /// </summary>
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height) 
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
