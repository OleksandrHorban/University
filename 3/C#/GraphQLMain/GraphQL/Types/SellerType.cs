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
    public class SellerType : ObjectType<Seller>
    {
        protected override void Configure(IObjectTypeDescriptor<Seller> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<SellerByIdDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(t => t.EventsSellers)
                .ResolveWith<SellerResolvers>(t => t.GetEventsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("events");
        }

        private class SellerResolvers
        {
            public async Task<IEnumerable<Event>> GetEventsAsync(
                Seller seller,
                [ScopedService] ApplicationDbContext dbContext,
                EventByIdDataLoader eventById,
                CancellationToken cancellationToken)
            {
                int[] sellerIds = await dbContext.Sellers
                    .Where(s => s.Id == seller.Id)
                    .Include(s => s.EventsSellers)
                    .SelectMany(s => s.EventsSellers.Select(t => t.EventId))
                    .ToArrayAsync();

                return await eventById.LoadAsync(sellerIds, cancellationToken);
            }
        }
    }
}
