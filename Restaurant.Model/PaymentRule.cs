namespace Restaurant.Model
{
    /// <summary>
    /// PaymentRule is a model to keep payment information such as actual price, discount or total price
    /// </summary>
    public class PaymentRule
    {
        public string Description { get; set; }
        public double ActualPrice { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
    }
}
