using ConferencePlanner.GraphQL.Data;
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Buyers
{
    public record CheckInBuyerInput(
        [ID(nameof(Event))]
        int EventId,
        [ID(nameof(Buyer))]
        int BuyerId);
}
