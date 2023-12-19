using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Buyers;
using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;

namespace ConferencePlanner.GraphQL.Categories
{
    [ExtendObjectType("Mutation")]
    public class CategoryMutations
    {
        [UseApplicationDbContext]
        public async Task<AddCategoryPayload> AddCategoryAsync(
            AddCategoryInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = input.Name,
                
            };

            context.Categories.Add(category);

            await context.SaveChangesAsync(cancellationToken);

            return new AddCategoryPayload(category);
        }
        [UseApplicationDbContext]
        public async Task<RenameCategoryPayload> RenameCategoryAsync(
            RenameCategoryInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            Category category = await context.Categories.FindAsync(input.Id);
            category.Name = input.Name;

            await context.SaveChangesAsync(cancellationToken);

            return new RenameCategoryPayload(category);
        }
    }
}
