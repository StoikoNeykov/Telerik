namespace SchoolClasses.Models
{
    using System;
    using SchoolClasses.Interfaces;

    public abstract class Person : IPerson
    {
        private string name;

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name have to be set!");
                }

                foreach (var ch in value)
                {
                    if (!Char.IsLetter(ch))
                    {
                        throw new ArgumentException("Invalid name!");
                    }
                }

                this.name = value;
            }
        }
    }
}
