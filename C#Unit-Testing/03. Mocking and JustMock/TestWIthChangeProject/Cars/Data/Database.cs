namespace Cars.Data
{
    using System.Collections.Generic;

    using Cars.Contracts;
    using Cars.Models;

    public class Database : IDatabase
    {
        public IList<ICar> Cars { get; set; }
    }
}
