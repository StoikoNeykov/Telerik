namespace AnimalHierarchy.Models
{
    using System;

    using Enumerations;
    using Interfaces;

    /// <summary>
    /// Parent class for animals. Only constuctor require all properties set!
    /// Sound() is abstract. All prop are read-only. 
    /// </summary>
    public abstract class Animal : ISound
    {
        private string name;

        private int age;

        private Gender sex;

        public Animal(string name, int age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                ValidateName(value);
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
                    throw new ArgumentException("Age cannot be negative number!");
                }

                this.age = value;
            }
        }

        public Gender Sex
        {
            get
            {
                return this.sex;
            }
            private set
            {
                this.sex = value;
            }
        }

        public abstract string Sound();

        public void IncreaseAge(int years)
        {
            if (years < 1)
            {
                throw new ArgumentException("Years is 0 or negative! Are you sure you really want to increase age?");
            }

            if (years > 100)
            {
                throw new ArgumentException(string.Format("{0} years is really too much!", years));
            }

            this.age += years;
        }

        public void Rename(string newName)
        {
            this.Name = newName;
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name have to be set!");
            }

            if (name.Length > 0)
            {
                foreach (var ch in name)
                {
                    if (!char.IsLetter(ch))
                    {
                        throw new ArgumentException("Invalid name!");
                    }
                }
            }
        }
    }
}
