using DecisionTech.PriceCalculation.Interfaces;
using DecisionTech.PriceCalculation.Models;
using System.Linq;

namespace DecisionTech.PriceCalculation.Services
{
    public class BasketService : IBasketService
    {

        public BasketService()
        {

        }

        public Basket CalculateTotal(Basket basket)
        {
            basket.Total = basket.Products.Sum(x => x.Quantity * x.Price);
            return basket;
        }
    }
}
