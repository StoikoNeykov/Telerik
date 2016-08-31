using System;
using Task2.PrintStatistics.Contracts;

namespace Task2.PrintStatistics.Workers
{
    /// <summary>
    /// Empty class made just to cover example
    /// </summary>
    public class Writer : IWriter
    {
        public void Write(double value)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(double value)
        {
            throw new NotImplementedException();
        }
    }
}
