namespace TestsHomework.Models
{
    using System;

    using Enumerations;
    using Interfaces;

    public abstract class Animal : ISound
    {
        private string name;

        private int age;

        private SexType sex;

        public Animal(string name, SexType sex)
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                this.age = value;
            }
        }

        public SexType Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public abstract string Sound();
    }
}
