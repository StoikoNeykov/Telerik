namespace Bank.Models
{
    using System;
    using Interfaces;

    public class DepositAccount : Account, IDrawable
    {
        public DepositAccount(decimal balance, Client costumer, decimal interestRate)
            : base(balance, costumer, interestRate)
        {
        }

        public override decimal CalculateInterestRate(int months)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }

            return months * this.InterestRate / 100;
        }

        public void Draw(decimal money)
        {
            if (money < 0 || money == 0)
            {
                throw new ArgumentException("You cannot draw negative or zero money!");
            }

            // Deposit accounts can be negative so no need to check for that
            this.Balance -= money;
        }
    }
}
