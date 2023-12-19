using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;

namespace ConferencePlanner.GraphQL.Sellers
{
    [ExtendObjectType("Mutation")]
    public class SellerMutations
    {
        [UseApplicationDbContext]
        public async Task<AddSellerPayload> AddSellerAsync(
            AddSellerInput input,
            [ScopedService] ApplicationDbContext context)
        {
            var seller = new Seller
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            context.Sellers.Add(seller);
            await context.SaveChangesAsync();

            return new AddSellerPayload(seller);
        }
    }
}
