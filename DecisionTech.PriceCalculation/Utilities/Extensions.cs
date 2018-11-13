using DecisionTech.PriceCalculation.Models;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTech.PriceCalculation.Utilities
{
    public static class Extensions
    {
        public static decimal CalculateDiscount(this IEnumerable<Product> products, IEnumerable<Discount> discounts)
        {
            return discounts.Join(products, 
                                  d => d.TargetProductId, 
                                  p => p.ProductId,
                                  (dis, prod) => new Product(prod.ProductId, 
                                                            prod.ProductName,
                                                            CalculateProductDiscountedPrice(prod, dis, products.FindByProductId(dis.ProductId)),
                                                            prod.Quantity ))
                                  .Sum(p => p.Price);
        }

        public static decimal CalculateTotal(this IEnumerable<Product> products)
        {
            return products.Sum(p => p.Quantity * p.Price);
        }

        public static Product FindByProductId(this IEnumerable<Product> products, int productId)
        {
            return products.First(p => p.ProductId == productId);
        }

        public static decimal CalculateProductDiscountedPrice(Product prod, Discount dis, Product targetProduct)
        {
            return prod.Price * (dis.Percentage / 100) * (targetProduct.Quantity / dis.Quantity);
        }
    }
}
