namespace Humans.Models
{
    using System;

    /// <summary>
    /// Base abstract class
    /// </summary>
    public abstract class Human
    {
        private string firstName;

        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.Lastname = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                ValidateName(value);
                this.firstName = value;
            }
        }

        public string Lastname
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                ValidateName(value);
                this.lastName = value;
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name have to be set!");
            }

            foreach (var ch in name)
            {
                if (!Char.IsLetter(ch))
                {
                    throw new ArgumentException("Invalid name!");
                }
            }
        }

        public override string ToString()
        {
            return string.Format($"{this.firstName} {this.lastName}");
        }
    }
}
