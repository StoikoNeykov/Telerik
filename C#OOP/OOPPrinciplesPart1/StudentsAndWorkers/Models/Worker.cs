namespace StudentsAndWorkers.Models
{
    using System;

    using Interfaces;

    /// <summary>
    /// Base + Salary
    /// </summary>
    public class Worker : Human, IHuman
    {
        private decimal weekSalary;

        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("WeekSalary cannot be negative!");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("WorkHoursPerDay cannot be negative number!");
                }

                if (value == 0)
                {
                    throw new ArgumentNullException("Is not posible to be worker if do not work!");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour
        {
            get
            {
                return this.WeekSalary / this.WorkHoursPerDay;
            }
        }

    }
}
