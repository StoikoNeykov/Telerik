namespace Bank.Models
{
    using System;

    public class Company : Client
    {
        public Company(string companyName)
        {
            this.CompanyName = companyName;
        }

        public string CompanyName
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

                this.name = value;
            }
        }
    }
}
