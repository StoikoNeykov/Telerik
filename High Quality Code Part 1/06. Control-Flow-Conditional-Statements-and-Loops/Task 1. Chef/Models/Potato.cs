using Kitchen.Contracts;

namespace Kitchen.Models
{
    public class Potato : Vegetable, IVegetable
    {
        public bool IsPeeled { get; set; }

        public bool IsRotten { get; set; }
    }
}
