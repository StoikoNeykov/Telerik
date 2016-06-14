namespace StudentsAndWorkers.Models
{
    using System;

    using Interfaces;

    /// <summary>
    /// Base class for students and workers. Implement IHuman
    /// </summary>
    public abstract class Human : IHuman
    {
        private string firstName;

        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                ValifateName(value);
                this.lastName = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                ValifateName(value);
                this.firstName = value;
            }
        }

        private void ValifateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name have to be set!");
            }

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
