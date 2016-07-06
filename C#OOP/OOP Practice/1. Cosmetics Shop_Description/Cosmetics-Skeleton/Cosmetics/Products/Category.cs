namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;
    using Extensions;

    public class Category : ICategory
    {
        private string name;
        private List<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
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
                            GlobalConstants.MaXCategoryNameLength,
                            GlobalConstants.MinCategoryNameLength,
                            string.Format(GlobalErrorMessages.InvalidStringLength,
                                                "Category name",
                                                GlobalConstants.MinCategoryNameLength,
                                                GlobalConstants.MaXCategoryNameLength));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public string Print()
        {
            var prods = this.products
                            .OrderBy(x => x.Brand)
                            .ThenByDescending(x => x.Price)
                            .Select(x => x.Print());

            string counting = this.products.Count != 1 ? "products" : "product";

            return string.Format("{0} category - {1} {2} in total{3}{4}",
                                    this.name,
                                    this.products.Count,
                                    counting,
                                    Environment.NewLine,
                                    string.Join(Environment.NewLine, prods)).Trim(); ;
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            var nullMessage = string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "cosmetics");
            Validator.CheckIfNull(cosmetics, nullMessage);

            if (this.products.Contains(cosmetics))
            {
                this.products.Remove(cosmetics);
            }
            else
            {
                var msgFormat = string.Format(GlobalErrorMessagesExtension.ProductNotFound,
                                                    cosmetics.Name,
                                                    this.Name);

                throw new ArgumentException(msgFormat);
            }
        }
    }
}
