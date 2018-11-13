using DecisionTech.PriceCalculation.Models;
using System.Collections.Generic;

namespace DecisionTech.PriceCalculation.Interfaces
{
    public interface IDiscountService
    {
        IEnumerable<Discount> GetDiscountsByProduct(IEnumerable<Product> products);
    }
}
