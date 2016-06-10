namespace DefineClassesAndStructs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Path is group of Point3D objects.
    /// </summary>
    public class Path
    {
        private List<Point3D> path;

        public Path()
        {
            this.path = new List<Point3D>();
        }

        public Path(IEnumerable<Point3D> collection)
            :this()
        {
            foreach (var point in collection)
            {
                this.path.Add(point);
            }
        }

        public void AddPoint(Point3D curentPoint)
        {
            this.path.Add(curentPoint);
        }

        public bool RemovePoint(Point3D curentPoint)
        {
            foreach (Point3D point in this.path)
            {
                if (curentPoint.Equals(point))
                {
                    this.path.Remove(point);
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            if (this.path.Count > 0)
            {
                var result = new List<string>();
                foreach (var point in this.path)
                {
                    result.Add(point.ToString());
                }

                return string.Join(" ", result);
            }

            return "This path is empty";
            
        }

        // format {x1, y1, z1} {x2, y2, z2} {x3, y3, z3} ... 
        public static Path Parse(string text)
        { 
            if (text == "This path is empty")
            {
                return new Path();
            }

            var result = text
                .Split(new[] { "} {" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Point3D.Parse);           
            return new Path(result);    
        }
    }
}
