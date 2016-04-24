using System;

    class ComparingFloats
    {
        static void Main()
        {
        double numOne = double.Parse(Console.ReadLine());
        double numTwo = double.Parse(Console.ReadLine());
        if(Math.Abs(numOne - numTwo) <= 0.000001)
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
        //forced to use if-else because
        //Console.WriteLine(Math.Abs(numOne - numTwo) <= 0.000001));
        // return True and False not true and false and fail the test! 
    }
}

