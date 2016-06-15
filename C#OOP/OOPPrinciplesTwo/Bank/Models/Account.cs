namespace Bank.Models
{
    using System;

    public abstract class Account
    {
        private decimal balance;

        private Client customer;

        private decimal interestRate;

        public Account(decimal balance, Client customer, decimal interestRate)
        {
            this.Balance = balance;
            this.Customer = customer;
            this.InterestRate = interestRate;
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            protected set
            {
                this.balance = value;
            }
        }

        public Client Customer
        {
            get
            {
                return this.customer;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer cannot be null!");
                }

                this.customer = value;
            }
        }
 
        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            private set
            {
                this.interestRate = value;
            }
        }

        public void Deposit(decimal money)
        {
            if (money < 0 || money == 0)
            {
                throw new ArgumentException("You cant deposit negative or zero money!");
            }

            this.balance += money;
        }

        public abstract decimal CalculateInterestRate(int months);

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Customer, this.Balance, this.InterestRate);
        }
    }
}
