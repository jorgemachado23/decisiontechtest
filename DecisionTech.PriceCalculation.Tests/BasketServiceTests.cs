using DecisionTech.PriceCalculation.Interfaces;
using DecisionTech.PriceCalculation.Models;
using DecisionTech.PriceCalculation.Services;
using System.Collections.Generic;
using Xunit;

namespace DecisionTech.PriceCalculation.Tests
{
    public class BasketServiceTests
    {
        readonly IBasketService _basketService;
        readonly IDiscountService _discountService;
        readonly IEnumerable<Discount> _discounts = ListDiscounts(); 

        public BasketServiceTests()
        {
            _discountService = new DiscountService(_discounts);
            _basketService = new BasketService(_discountService);
        }

        [Fact]
        public void Should_Calculate_Basket_Total_No_Discounts_Apply()
        {
            var products = new Product[] 
            {
                new Product(1,"Bread", 1, 1),
                new Product(2,"Butter", 0.8m,1),
                new Product(3,"Milk", 1.15m, 1)
            };

            var basket = new Basket(products);
            TestAssertion(2.95m, basket);
        }

        [Fact]
        public void Should_Calculate_Basket_Total_With_One_Discounts()
        {
            var products = new Product[]
            {
                new Product(1,"Bread", 1, 2),
                new Product(2,"Butter", 0.8m,2),
            };

            var basket = new Basket(products);
            TestAssertion(3.10m, basket);

            products = new Product[]
            {
                new Product(3,"Milk",1.15m, 4)
            };

            basket.Products = products;

            TestAssertion(3.45m, basket);
        }

        [Fact]
        public void Should_Calculate_Basket_Total_With_Multiple_Discounts()
        {
            var products = new Product[]
            {
                new Product(1,"Bread", 1, 1),
                new Product(2,"Butter", 0.8m, 2),
                new Product(3,"Milk", 1.15m, 8)
            };

            var basket = new Basket(products);
            TestAssertion(9m, basket);
        }

        private void TestAssertion(decimal total, Basket basket)
        {
            basket = _basketService.CalculateTotal(basket);
            Assert.Equal(total, basket.Total);
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
