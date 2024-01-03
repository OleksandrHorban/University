using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.DataLoader
{
    public class BuyerByIdDataLoader : BatchDataLoader<int, Buyer>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public BuyerByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<ApplicationDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Buyer>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Buyers
                .Where(b => keys.Contains(b.Id))
                .ToDictionaryAsync(b => b.Id, cancellationToken);
        }
    }
}

