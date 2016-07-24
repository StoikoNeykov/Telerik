namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Common;
    using Extensions;

    public class Shampoo : Product, IProduct, IShampoo
    {
        private uint milliliters;
        private UsageType usage;

        public Shampoo(string brand, GenderType gender, string name, decimal price, uint milliliters, UsageType usage)
            : base(brand, gender, name, price)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            private set
            {
                ValidatorExtension.CheckIfUintIsZero(value, "Milliliters");
                this.milliliters = value;
            }
        }

        public new decimal Price
        {
            get
            {
                return base.Price * this.Milliliters;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            private set
            {
                this.usage = value;
            }
        }

        public override string Print()
        {

            var result = base.Print()
                                .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                                .ToList();
            var price = string.Format("  * Price: ${0}", this.Price);
            result.RemoveAt(1);
            result.Insert(1, price);

            return string.Format("{0}{1}  * Quantity: {2} ml{1}  * Usage: {3}",
                                     string.Join(Environment.NewLine, result),
                                    Environment.NewLine,
                                    this.milliliters,
                                    this.usage);
        }

    }
}
