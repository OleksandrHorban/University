using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate;
using HotChocolate.Types;

namespace ConferencePlanner.GraphQL.Events
{
    [ExtendObjectType(Name = "Subscription")]
    public class EventSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<Event> OnEventScheduledAsync(
            [EventMessage] int eventId,
            EventByIdDataLoader eventById,
            CancellationToken cancellationToken) =>
            eventById.LoadAsync(eventId, cancellationToken);
    }
}
