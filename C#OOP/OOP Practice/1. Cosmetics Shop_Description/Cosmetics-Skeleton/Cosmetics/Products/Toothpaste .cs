namespace Cosmetics.Products
{
    using System;
    using Common;
    using Contracts;

    public class Toothpaste : Product, IProduct, IToothpaste
    {
        private string ingredients;

        public Toothpaste(string brand, GenderType gender, string name, decimal price, string ingredients)
            : base(brand, gender, name, price)
        {
            this.Ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            private set
            {
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            return string.Format("{0}{1}  * Ingredients: {2}",
                                    base.Print(),
                                    Environment.NewLine,
                                    this.ingredients);
        }
    }
}
