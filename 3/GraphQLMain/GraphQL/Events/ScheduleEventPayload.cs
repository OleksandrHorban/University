using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate;

namespace ConferencePlanner.GraphQL.Events
{
    public class ScheduleEventPayload : EventPayloadBase
    {
        public ScheduleEventPayload(Event @event)
            : base(@event)
        {
        }

        public ScheduleEventPayload(UserError error)
            : base(new[] { error })
        {
        }

        public async Task<Category?> GetTrackAsync(
            CategoryByIdDataLoader trackById,
            CancellationToken cancellationToken)
        {
            if (Event is null)
            {
                return null;
            }

            return (Category?)await trackById.LoadAsync(Event.CategoryId, cancellationToken);
        }

        [UseApplicationDbContext]
        public async Task<IEnumerable<Seller>?> GetSellersAsync(
            [ScopedService] ApplicationDbContext dbContext,
            SellerByIdDataLoader sellerById,
            CancellationToken cancellationToken)
        {
            if (Event is null)
            {
                return null;
            }

            int[] sellerIds = await dbContext.EventSellers
                .Where(es => es.EventId == Event.Id)
                .Select(es => es.SellerId)
                .ToArrayAsync();

            return await sellerById.LoadAsync(sellerIds, cancellationToken);
        }
    }
}


