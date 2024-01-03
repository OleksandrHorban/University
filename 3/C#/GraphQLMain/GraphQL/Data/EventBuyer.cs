namespace ConferencePlanner.GraphQL.Data
{
    public class EventBuyer
    {
        public int EventId { get; set; }

        public Event? Event { get; set; }

        public int BuyerId { get; set; }

        public Buyer? Buyer { get; set; }
    }
}
