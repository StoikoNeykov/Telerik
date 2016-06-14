namespace AnimalHierarchy.Models
{
    using System;
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// Is not prince turn to frog! Extra prop color and can talk
    /// </summary>
    public class Frog : Animal, ISound
    {
        private string color;

        public Frog(string name, int age, SexType sex, string color)
            : base(name, age, sex)
        {
            this.Color = color;
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                this.color = value;
            }
        }

        public string Talk()
        {
            return string.Format("First time you see {0} colored frog?", this.Color);
        }

        public override string Sound()
        {
            return "Croak";
        }
    }
}
