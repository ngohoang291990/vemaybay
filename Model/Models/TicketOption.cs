namespace Model.Models
{
    public class TicketOption
    {
        public virtual string Id { get; set; }

        public virtual decimal Price { get; set; }

        public virtual short Stops { get; set; }

        public virtual string TicketType { get; set; }

        public virtual decimal TotalPrice { get; set; }

        public string FareBasis { get; set; }
    }
}