using System;

namespace Abstraction
{
    public abstract class Figure
    {
        // prolly not best place but another class with error msgs for 1 constant is too much
        protected readonly string InvalidParameterError = "{0} cannot be negative or zero!";

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        public override string ToString()
        {
            return string.Format("My perimeter is {0:f2}. My surface is {1:f2}.",
                this.CalcPerimeter(), this.CalcSurface());
        }
    }
}
