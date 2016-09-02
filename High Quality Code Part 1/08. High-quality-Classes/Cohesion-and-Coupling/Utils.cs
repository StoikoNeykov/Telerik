using System;

namespace CohesionAndCoupling
{
    static class Utils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcDiagonalXYZ(IFigure3D figure)
        {
            double distance = CalcDistance3D(0, 0, 0, figure.Width, figure.Height, figure.Depth);
            return distance;
        }

        public static double CalcDiagonalXY(IFigure3D figure)
        {
            double distance = CalcDistance2D(0, 0, figure.Width, figure.Height);
            return distance;
        }

        public static double CalcDiagonalXZ(IFigure3D figure)
        {
            double distance = CalcDistance2D(0, 0, figure.Width, figure.Depth);
            return distance;
        }

        public static double CalcDiagonalYZ(IFigure3D figure)
        {
            double distance = CalcDistance2D(0, 0, figure.Height, figure.Depth);
            return distance;
        }
    }
}
