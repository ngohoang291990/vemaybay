namespace Model.Models
{
    public class PriceSummary
    {
        public string PassengerType { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }
    }
}