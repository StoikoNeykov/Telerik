using System;

    class PointCircleRectangle
    {
        static void Main()
        {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double newX = x - 1;
        double newY = y - 1;
        double distance = Math.Sqrt(newX*newX + newY*newY);
        bool inC = (distance <= 1.5 ? true : false);
        bool inR = ((-1<=y)&&(y<=1)&&(-1<=x)&&(x<=5) ? true : false);
        string c = inC ? "inside circle" : "outside circle";
        string r = inR ? "inside rectangle" : "outside rectangle";
        Console.WriteLine("{0} {1}",c,r);
        }
    }

