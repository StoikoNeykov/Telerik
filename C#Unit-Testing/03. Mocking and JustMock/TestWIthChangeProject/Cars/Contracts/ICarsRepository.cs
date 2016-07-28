namespace Cars.Contracts
{
    using Cars.Models;
    using System.Collections.Generic;

    public interface ICarsRepository
    {
        int TotalCars{get;}

        void Add(ICar car);

        void Remove(ICar car);

        ICar GetById(int id);

        ICollection<ICar> All();

        ICollection<ICar> SortedByMake();

        ICollection<ICar> SortedByYear();

        ICollection<ICar> Search(string condition);
    }
}
