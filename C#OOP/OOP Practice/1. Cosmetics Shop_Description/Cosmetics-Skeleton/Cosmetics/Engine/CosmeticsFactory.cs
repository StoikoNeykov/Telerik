namespace Cosmetics.Engine
{
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Extensions;
    using Cosmetics.Products;

    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            return new Category(name);
        }

        public IShampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            return new Shampoo(brand, gender, name, price, milliliters, usage);
        }

        public IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            ValidatorExtension.CheckIfIngredientsAreValid(ingredients);
            var ings = string.Join(", ", ingredients);
            return new Toothpaste(brand, gender, name, price, ings);
        }

        public IShoppingCart ShoppingCart()
        {
            return new ShoppingCart();
        }
    }
}
