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
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Types
{
    public class EventType : ObjectType<Event>
    {
        protected override void Configure(IObjectTypeDescriptor<Event> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<EventByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(t => t.EventSellers)
                .ResolveWith<EventResolvers>(t => t.GetSellersAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("sellers");

            descriptor
                .Field(t => t.EventBuyers)
                .ResolveWith<EventResolvers>(t => t.GetBuyersAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("buyers");

            descriptor
                .Field(t => t.Category)
                .ResolveWith<EventResolvers>(t => t.GetCategoriesAsync(default!, default!, default));

            descriptor
                .Field(t => t.CategoryId)
                .ID(nameof(Category));
        }

        private class EventResolvers
        {
            public async Task<IEnumerable<Seller>> GetSellersAsync(
                Event @event,
                [ScopedService] ApplicationDbContext dbContext,
                SellerByIdDataLoader sellerById,
                CancellationToken cancellationToken)
            {
                int[] sellerIds = await dbContext.Events
                    .Where(e => e.Id == @event.Id)
                    .Include(e => e.EventSellers)
                    .SelectMany(e => e.EventSellers.Select(es => es.SellerId))
                    .ToArrayAsync();

                return await sellerById.LoadAsync(sellerIds, cancellationToken);
            }

            public async Task<IEnumerable<Buyer>> GetBuyersAsync(
                Event @event,
                [ScopedService] ApplicationDbContext dbContext,
                BuyerByIdDataLoader buyerById,
                CancellationToken cancellationToken)
            {
                int[] buyerIds = await dbContext.Events
                    .Where(e => e.Id == @event.Id)
                    .Include(e => e.EventBuyers)
                    .SelectMany(e => e.EventBuyers.Select(ea => ea.BuyerId))
                    .ToArrayAsync();

                return await buyerById.LoadAsync(buyerIds, cancellationToken);
            }

            public async Task<Category?> GetCategoriesAsync(
                Event @event,
                CategoryByIdDataLoader categoryById,
                CancellationToken cancellationToken)
            {
                if (@event.CategoryId is null)
                {
                    return null;
                }

                return await categoryById.LoadAsync(@event.CategoryId.Value, cancellationToken);
            }
        }
    }
}

