namespace Cosmetics.Products
{
    using System;
    using Contracts;
    using Common;
    using Extensions;

    public abstract class Product : IProduct
    {
        private string brand;
        private GenderType gender;
        private string name;
        private decimal price;

        public Product(string brand, GenderType gender, string name, decimal price)
        {
            this.Brand = brand;
            this.Gender = gender;
            this.Name = name;
            this.Price = price;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value,
                    GlobalConstants.MaxBrandLength,
                    GlobalConstants.MinBrandLenght,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", GlobalConstants.MinBrandLenght, GlobalConstants.MaxBrandLength));
                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                this.gender = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value,
                                                        GlobalConstants.MaxProductNameLength,
                                                        GlobalConstants.MinProductNameLength,
                                                        string.Format(GlobalErrorMessages.InvalidStringLength,
                                                                            "Product name", 
                                                                            GlobalConstants.MinProductNameLength, 
                                                                            GlobalConstants.MaxProductNameLength));
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                ValidatorExtension.CheckIfDecimalIsNegative(value, "Price");
                this.price = value;
            }
        }

        public virtual string Print()
        {
            return string.Format("- {0} - {1}:{2}  * Price: ${3}{2}  * For gender: {4}",
                this.brand,
                this.name,
                Environment.NewLine,
                this.price,
                this.gender);
        }

    }
}
