using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.DataLoader
{
    public class EventByIdDataLoader : BatchDataLoader<int, Event>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public EventByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<ApplicationDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Event>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Events
                .Where(e => keys.Contains(e.Id))
                .ToDictionaryAsync(e => e.Id, cancellationToken);
        }
    }
}

