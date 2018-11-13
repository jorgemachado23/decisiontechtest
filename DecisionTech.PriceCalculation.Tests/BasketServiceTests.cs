using DecisionTech.PriceCalculation.Interfaces;
using DecisionTech.PriceCalculation.Models;
using DecisionTech.PriceCalculation.Services;
using Xunit;

namespace DecisionTech.PriceCalculation.Tests
{
    public class BasketServiceTests
    {
        readonly IBasketService _basketService;
        readonly IDiscountService _discountService;

        public BasketServiceTests()
        {
            _discountService = new DiscountService(ListDiscounts());
            _basketService = new BasketService(_discountService);
        }

        [Fact]
        public void Should_Calculate_Basket_Total()
        {
            var products = new Product[] 
            {
                new Product(1,"Bread", 1, 1),
                new Product(2,"Butter", 0.8m,1),
                new Product(3,"Milk", 1.15m, 1)
            };

            var basket = new Basket(products);
            //basket = _basketService.CalculateTotal(basket);
            //Assert.Equal(2.95m, basket.Total);

            //products = new Product[]
            //{
            //    new Product(1,"Bread", 1, 2),
            //    new Product(2,"Butter", 0.8m,2),
            //};

            //basket.Products = products;
            //basket = _basketService.CalculateTotal(basket);
            //Assert.Equal(3.10m, basket.Total);

            //products = new Product[]
            //{
            //    new Product(3,"Milk",1.15m, 4)
            //};

            //basket.Products = products;
            //basket = _basketService.CalculateTotal(basket);
            //Assert.Equal(3.45m, basket.Total);


            products = new Product[]
            {
                new Product(1,"Bread", 1, 1),
                new Product(2,"Butter", 0.8m, 2),
                new Product(3,"Milk", 1.15m, 8)
            };

            basket.Products = products;
            basket = _basketService.CalculateTotal(basket);
            Assert.Equal(9m, basket.Total);
        }

        private static Discount[] ListDiscounts()
        {
            return new Discount[] 
            {
                new Discount(2, 2, 1, 50),
                new Discount(4, 3, 3, 100)
            };
        }
    }
}
