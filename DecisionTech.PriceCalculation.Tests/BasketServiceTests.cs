using DecisionTech.PriceCalculation.Interfaces;
using DecisionTech.PriceCalculation.Models;
using Xunit;

namespace DecisionTech.PriceCalculation.Tests
{
    public class BasketServiceTests
    {
        readonly IBasketService _basketService;

        [Fact]
        public void Should_Calculate_Basket_Total()
        {
            var products = new Product[] 
            {
                new Product("Bread", 1, 1),
                new Product("Butter", 0.8m,1),
                new Product("Milk", 1.15m, 1)
            };

            var basket = new Basket(products);
            basket  = _basketService.CalculateTotal(basket);
            Assert.Equal(2.95m, basket.Total);
        }
    }
}
