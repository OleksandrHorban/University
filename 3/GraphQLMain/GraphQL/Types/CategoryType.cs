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
    public class CategoryType : ObjectType<Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) =>
                    ctx.DataLoader<CategoryByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(t => t.Events)
                .ResolveWith<CategoryResolvers>(t => t.GetEventsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .UsePaging<NonNullType<EventType>>()
                .Name("events");

            descriptor
                .Field(t => t.Name)
                .UseUpperCase();
        }

        private class CategoryResolvers
        {
            public async Task<IEnumerable<Event>> GetEventsAsync(
                Category category,
                [ScopedService] ApplicationDbContext dbContext,
                EventByIdDataLoader eventById,
                CancellationToken cancellationToken)
            {
                int[] eventIds = await dbContext.Events
                    .Where(e => e.CategoryId == category.Id)
                    .Select(e => e.Id)
                    .ToArrayAsync();

                return await eventById.LoadAsync(eventIds, cancellationToken);
            }
        }
    }
}
