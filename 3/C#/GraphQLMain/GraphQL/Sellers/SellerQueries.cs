using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Sellers
{
    [ExtendObjectType("Query")]
    public class SellerQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        public IQueryable<Seller> GetSellers(
            [ScopedService] ApplicationDbContext context) =>
            context.Sellers.OrderBy(t => t.Name);

        public Task<Seller> GetSellerByIdAsync(
            [ID(nameof(Seller))] int id,
            SellerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Seller>> GetSellersByIdAsync(
            [ID(nameof(Seller))] int[] ids,
            SellerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(ids, cancellationToken);
    }
}
