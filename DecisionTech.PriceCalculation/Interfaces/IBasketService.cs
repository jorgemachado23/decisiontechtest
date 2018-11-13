using DecisionTech.PriceCalculation.Models;

namespace DecisionTech.PriceCalculation.Interfaces
{
    public interface IBasketService
    {
         Basket CalculateTotal(Basket basket);
    }
}
