using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Buyers
{
    [ExtendObjectType(Name = "Query")]
    public class BuyerQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        public async Task<List<Buyer>> GetBuyersAsync([ScopedService] ApplicationDbContext context)
        {
            return await context.Buyers.ToListAsync();
        }

        public async Task<Buyer> GetBuyerByIdAsync(
            [ID(nameof(Buyer))] int id,
            BuyerByIdDataLoader buyerById,
            CancellationToken cancellationToken)
        {
            return await buyerById.LoadAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Buyer>> GetBuyersByIdAsync(
            [ID(nameof(Buyer))] int[] ids,
            BuyerByIdDataLoader buyerById,
            CancellationToken cancellationToken)
        {
            return await buyerById.LoadAsync(ids, cancellationToken);
        }
    }
}

