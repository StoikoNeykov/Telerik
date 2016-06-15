namespace Shapes.Models
{
    /// <summary>
    /// Represent square. Using all from Rectangle just have diferent constructor
    /// </summary>
    public class Square : Rectangle
    {
        public Square(double width)
            : base(width, width)
        {
        }
    }
}
