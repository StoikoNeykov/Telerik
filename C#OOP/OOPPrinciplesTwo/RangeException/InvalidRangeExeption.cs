namespace RangeException
{
    using System;

    public class InvalidRangeExeption<T> : Exception
    {
        public InvalidRangeExeption(T start, T end, string msg = "Invalid range!", Exception inner = null)
            : base(string.Format("{0} Expected parameter in range: {1} - {2}", msg, start, end), inner)
        {

        }
    }
}
