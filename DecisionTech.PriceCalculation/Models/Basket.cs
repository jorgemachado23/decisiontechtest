using System.Collections.Generic;

namespace DecisionTech.PriceCalculation.Models
{
    public class Basket
    {

        public Basket(IEnumerable<Product> products)
        {
            Products = products;
        }

        public decimal Total { get; set; }

        IEnumerable<Product> Products { get; set; }
    }
}
