namespace DecisionTech.PriceCalculation.Models
{
    public class Discount
    {
        public Discount(int quantity, int productId, int targetProductId, int percentage)
        {
            Quantity = quantity;
            ProductId = productId;
            TargetProductId = targetProductId;
            Percentage = percentage;
        }

        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int TargetProductId { get; set; }
        public decimal Percentage { get; set; }
    }
}
