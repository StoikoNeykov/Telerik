namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;
    using Extensions;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> shopCart;

        public ShoppingCart()
        {
            this.shopCart = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "product"));
            this.shopCart.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            foreach (IProduct prod in this.shopCart)
            {
                if (prod.Equals(product))
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "product"));
            this.shopCart.Remove(product);
        }

        public decimal TotalPrice()
        {
            var result = this.shopCart
                            .Select(x => x.Price)
                            .Sum();

            return result;
                
        }
    }
}
