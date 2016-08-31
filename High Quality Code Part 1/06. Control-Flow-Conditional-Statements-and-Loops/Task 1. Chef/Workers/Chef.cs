using Kitchen.Contracts;
using Kitchen.Models;

namespace Kitchen.Workers
{
    public class Chef
    {
        public void Cook()
        {
            Bowl bowl = GetBowl();

            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();

            Peel(potato);
            Cut(potato);
            bowl.Add(potato);

            Peel(carrot);
            Cut(carrot);
            bowl.Add(carrot);

        }

        public void Cook(IVegetable vegetable)
        {
            // ... do nothing!
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private void Cut(IVegetable vegetable)
        {
            //... do nothing!
        }

        private void Peel(IVegetable vegetable)
        {
            // ... do nothing!
        }
    }
}
