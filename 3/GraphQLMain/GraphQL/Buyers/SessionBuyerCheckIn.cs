using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate;
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Buyers
{
    public class EventBuyerCheckIn
    {
        public EventBuyerCheckIn(int buyerId, int eventId)
        {
            BuyerId = buyerId;
            EventId = eventId;
        }

        [ID(nameof(Buyer))]
        public int BuyerId { get; }

        [ID(nameof(Event))]
        public int EventId { get; }

        [UseApplicationDbContext]
        public async Task<int> CheckInCountAsync(
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.Events
                .Where(e => e.Id == EventId)
                .SelectMany(e => e.EventBuyers)
                .CountAsync(cancellationToken);

        public Task<Buyer> GetBuyerAsync(
            BuyerByIdDataLoader buyerById,
            CancellationToken cancellationToken) =>
            buyerById.LoadAsync(BuyerId, cancellationToken);

        public Task<Event> GetEventAsync(
            EventByIdDataLoader eventById,
            CancellationToken cancellationToken) =>
            eventById.LoadAsync(EventId, cancellationToken);
    }
}
