namespace DefineClassesAndStructs
{
    using System;

    public static class CalcPointsDistance
    {
        public static decimal PointsDistance(Point3D first, Point3D second)
        {
            var result = Math.Sqrt(Math.Pow((first.DoubleX - second.DoubleX), 2) +
                Math.Pow((first.DoubleY - second.DoubleY), 2) +
                Math.Pow((first.DoubleZ - second.DoubleZ), 2));

            return (decimal)result;
        }
    }
}
