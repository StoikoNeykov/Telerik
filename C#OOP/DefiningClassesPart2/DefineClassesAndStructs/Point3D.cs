namespace DefineClassesAndStructs
{
    using System;

    /// <summary>
    /// Struct that hold information about point in 3D
    /// </summary>
    public struct Point3D
    {
        private static readonly Point3D O = new Point3D(0m, 0m, 0m);

        public Point3D(decimal x = 0m, decimal y = 0m, decimal z = 0m)
        {
            this.CoordX = x;
            this.CoordY = y;
            this.CoordZ = z;
        }

        public Point3D(double x = 0, double y = 0, double z = 0)
            : this((decimal)x, (decimal)y, (decimal)z)
        {
        }

        public Point3D(int x = 0, int y = 0, int z = 0)
            : this((decimal)x, (decimal)y, (decimal)z)
        {
        }

        public decimal CoordX { get; set; }

        public decimal CoordY { get; set; }

        public decimal CoordZ { get; set; }

        public double DoubleX
        {
            get
            {
                return (double)this.CoordX;
            }
        }

        public double DoubleY
        {
            get
            {
                return (double)this.CoordY;
            }
        }

        public double DoubleZ
        {
            get
            {
                return (double)this.CoordZ;
            }
        }

        public static Point3D Zero
        {
            get
            {
                return O;
            }
        }

        public override string ToString()
        {
            return string.Format("{{{0}, {1}, {2}}}", this.CoordX, this.CoordY, this.CoordZ);
        }

        // is not override coz standart Equals expect any type of object. My method works with Point3D 
        public bool Equals(Point3D curentPoint)
        {
            if (this.CoordX == curentPoint.CoordX &&
                this.CoordY == curentPoint.CoordY &&
                this.CoordZ == curentPoint.CoordZ)
            {
                return true;
            }
            return false;
        }

        // string must be in format {x, y, z} 
        public static Point3D Parse(string text)
        {
            var result = text.Split(new[] { " ", ",", "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
            return new Point3D(decimal.Parse(result[0]), decimal.Parse(result[1]), decimal.Parse(result[2]));
        }
    }
}
