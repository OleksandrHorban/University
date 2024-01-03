namespace ConferencePlanner.GraphQL.Data
{
    public class EventSeller
    {
        public int EventId { get; set; }

        public Event? Event { get; set; }

        public int SellerId { get; set; }

        public Seller? Seller { get; set; }
    }
}
