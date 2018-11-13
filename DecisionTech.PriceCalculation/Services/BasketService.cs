using DecisionTech.PriceCalculation.Interfaces;
using DecisionTech.PriceCalculation.Models;
using DecisionTech.PriceCalculation.Utilities;

namespace DecisionTech.PriceCalculation.Services
{
    public class BasketService : IBasketService
    {
        readonly IDiscountService _discountService;

        public BasketService(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public Basket CalculateTotal(Basket basket)
        {
            var currentDiscounts = _discountService.GetDiscountsByProduct(basket.Products);
            var subTotal = basket.Products.CalculateTotal();
            var discount = basket.Products.CalculateDiscount(currentDiscounts);
            basket.Total = subTotal - discount;
            return basket;
        }
    }
}
