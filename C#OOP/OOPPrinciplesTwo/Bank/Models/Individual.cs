namespace Bank.Models
{
    using System;

    public class Individual : Client
    {
        public Individual(string name)
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
                ValidateName(value);
                this.name = value;
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name have to be set!");
            }

            foreach (var ch in name)
            {
                if (!Char.IsLetter(ch))
                {
                    throw new ArgumentException("Invalid name!");
                }
            }
        }
    }
}
