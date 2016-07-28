namespace Cars.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cars.Contracts;
    using Cars.Models;

    public class CarsRepository : ICarsRepository
    {
        public CarsRepository()
            : this(new Database())
        {
        }

        public CarsRepository(IDatabase database)
        {
            this.Data = database;
        }

        protected IDatabase Data { get; set; }

        public int TotalCars
        {
            get
            {
                return this.Data.Cars.Count;
            }
        }

        public void Add(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException("Null car cannot be added");
            }

            this.Data.Cars.Add(car);
        }

        public void Remove(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException("Null car cannot be removed");
            }

            this.Data.Cars.Remove(car);
        }

        public ICar GetById(int id)
        {
            var car = this.Data.Cars.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                throw new ArgumentException("Car with such Id could not be found");
            }

            return car;
        }

        public ICollection<ICar> All()
        {
            return this.Data.Cars.ToList();
        }

        public ICollection<ICar> SortedByMake()
        {
            return this.Data.Cars.OrderBy(c => c.Make).ToList();
        }

        public ICollection<ICar> SortedByYear()
        {
            return this.Data.Cars.OrderByDescending(c => c.Year).ToList();
        }

        public ICollection<ICar> Search(string condition)
        {
            if (string.IsNullOrEmpty(condition))
            {
                return this.Data.Cars.ToList();
            }

            return this.Data.Cars.Where(c => c.Make == condition || c.Model == condition).ToList();
        }
    }
}
