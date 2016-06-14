namespace Humans.Models
{
    using System;

    public class Worker : Human
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
                    throw new ArgumentException("WeekSalary cannot be negative! Nobody pay to work somewhere!");
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
                    throw new ArgumentException("Work hours per day cannot be negative number!");
                }

                if (value == 0)
                {
                    throw new ArgumentNullException("Human who doesn`t work is not a worker!");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return this.weekSalary / (5 * this.workHoursPerDay);
        }

        public override string ToString()
        {
            return string.Format("{0:f2} {1}", this.MoneyPerHour(), base.ToString());
        }
    }
}