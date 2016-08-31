using System.Collections.Generic;

using Kitchen.Contracts;

namespace Kitchen.Models
{
    public class Bowl
    {
        private ICollection<IVegetable> vegetables = new List<IVegetable>();
        private ICollection<ISpice> Spices = new List<ISpice>();
        private ICollection<ISouce> Souces = new List<ISouce>();

        public void Add(IVegetable vegetable)
        {
            this.vegetables.Add(vegetable);
        }

        public void Add(ISpice spice)
        {
            this.Spices.Add(spice);
        }

        public void Add(ISouce souce)
        {
            this.Souces.Add(souce);
        }
    }
}
