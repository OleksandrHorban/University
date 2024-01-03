using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using ConferencePlanner.GraphQL.Types;

namespace ConferencePlanner.GraphQL.Events
{
    [ExtendObjectType("Query")]
    public class EventQueries
    {
        [UseApplicationDbContext]
        [UsePaging(typeof(NonNullType<EventType>))]
        [UseFiltering]
        [UseSorting]
        public Task<List<Event>> GetEvents(
            [ScopedService] ApplicationDbContext context) =>
            context.Events.ToListAsync();

        public Task<Event> GetEventByIdAsync(
            [ID(nameof(Event))] int id,
            EventByIdDataLoader eventById,
            CancellationToken cancellationToken) =>
            eventById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Event>> GetEventsByIdAsync(
            [ID(nameof(Event))] int[] ids,
            EventByIdDataLoader eventById,
            CancellationToken cancellationToken) =>
            await eventById.LoadAsync(ids, cancellationToken);
    }
}
