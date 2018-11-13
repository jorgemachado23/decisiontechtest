namespace DecisionTech.PriceCalculation.Models
{
    public class Product
    {
        public Product(string productName, decimal price, int quantity)
        {
            ProductName = productName;
            Price = price;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
