using System;

namespace Bank.Models
{
    public class LoanAccount : Account
    {
        public LoanAccount(decimal balance, Client costumer, decimal interestRate)
            : base(balance, costumer, interestRate)
        {
        }

        public override decimal CalculateInterestRate(int months)
        {
            int emptyMonths;
            if (this.Customer is Individual)
            {
                emptyMonths = 3;
            }
            // else mean this.Customer is Company
            else
            {
                emptyMonths = 2;
            }

            if (months <= emptyMonths)
            {
                return 0;
            }
            else
            {
                return this.InterestRate * (months - emptyMonths) / 100;
            }
        }
    }
}
