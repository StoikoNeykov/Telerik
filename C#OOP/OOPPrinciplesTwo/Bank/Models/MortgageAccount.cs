using System;

namespace Bank.Models
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(decimal balance, Client costumer, decimal interestRate)
            : base(balance, costumer, interestRate)
        {
        }

        public override decimal CalculateInterestRate(int months)
        {
            if (this.Customer is Individual)
            {
                if (months <= 6)
                {
                    return 0;
                }
                else
                {
                    return this.InterestRate * (months - 6) / 100;
                }
            }
            //esle this.Customer is Company
            else
            {
                if (months <= 12)
                {
                    return this.InterestRate * months / 200;
                }
                else
                {
                    return this.InterestRate * 12 / 200 + this.InterestRate * (months - 12) / 100;
                }
            }
        }
    }
}
