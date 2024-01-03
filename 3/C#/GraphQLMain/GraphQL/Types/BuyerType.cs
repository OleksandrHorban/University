using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace ConferencePlanner.GraphQL.Types
{
    public class BuyerType : ObjectType<Buyer>
    {
        protected override void Configure(IObjectTypeDescriptor<Buyer> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<BuyerByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(t => t.EventsBuyers)
                .ResolveWith<BuyerResolvers>(t => t.GetEventsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("events");
        }

        private class BuyerResolvers
        {
            public async Task<IEnumerable<Event>> GetEventsAsync(
                Buyer buyer,
                [ScopedService] ApplicationDbContext dbContext,
                EventByIdDataLoader eventById,
                CancellationToken cancellationToken)
            {
                int[] eventIds = await dbContext.Buyers
                    .Where(b => b.Id == buyer.Id)
                    .Include(b => b.EventsBuyers)
                    .SelectMany(b => b.EventsBuyers.Select(eb => eb.EventId))
                    .ToArrayAsync();

                return await eventById.LoadAsync(eventIds, cancellationToken);
            }
        }
    }
}

