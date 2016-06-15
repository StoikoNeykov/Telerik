namespace Bank.Models
{
    using System.Collections.Generic;

    public abstract class Client
    {
        protected string name;

        public override string ToString()
        {
            return this.name;
        }
    }
}
