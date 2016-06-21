namespace DefineClassesAndStructs
{
    using System;

    /// <summary>
    /// Class for testing Point3D and Path
    /// </summary>
    public static class Test
    {
        public static void PointAndPathTest()
        {
            var pointA = new Point3D(1, 1.6, 1);
            var pointB = new Point3D(2, 1, 1);
            var pointC = new Point3D(1, 3);
            var pointD = new Point3D();
            var pointE = new Point3D(5.6, 12, 13.0);

            Console.WriteLine(CalcPointsDistance.PointsDistance(pointA, pointD));

            var path = new Path();
            path.AddPoint(pointA);
            path.AddPoint(pointB);
            path.AddPoint(pointC);
            path.AddPoint(pointD);
            path.AddPoint(pointE);
            // Console.WriteLine(path);

            var result = path.ToString();

            var myNewPath = Path.Parse(result);

            Console.WriteLine(myNewPath);

            path = new Path();

            PathStorage.SavePath(myNewPath, "123");

            path = PathStorage.LoadPath("123");

            Console.WriteLine(path);
        }
    }
}