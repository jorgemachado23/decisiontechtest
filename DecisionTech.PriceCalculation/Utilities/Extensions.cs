using DecisionTech.PriceCalculation.Models;
using System.Collections.Generic;
using System;
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
                                  (dis, prod) => new Product(prod.ProductId, prod.ProductName, prod.Price * (dis.Percentage/100) * (products.First(p => p.ProductId == dis.ProductId).Quantity / dis.Quantity), prod.Quantity ))
                                  .Sum(p => p.Price);
        }

        public static decimal CalculateTotal(this IEnumerable<Product> products)
        {
            return products.Sum(p => p.Quantity * p.Price);
        }

    }
}
