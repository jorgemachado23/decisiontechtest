using DecisionTech.PriceCalculation.Interfaces;
using DecisionTech.PriceCalculation.Models;
using System.Linq;
using System.Collections.Generic;

namespace DecisionTech.PriceCalculation.Services
{
    public class DiscountService : IDiscountService
    {
        readonly IEnumerable<Discount> _discounts;

        public DiscountService(IEnumerable<Discount> discounts)
        {
            _discounts = discounts;
        }
        
        public IEnumerable<Discount> GetDiscountsByProduct(IEnumerable<Product> products)
        {
            return _discounts.Join(products, d => d.ProductId, p => p.ProductId, (discount, produc) => new { discount, produc })
                              .Where(x => x.produc.Quantity >= x.discount.Quantity)
                              .Select(x => x.discount);
        }
    }
}
