using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Categories
{
    [ExtendObjectType("Query")]
    public class CategoryQueries
    {
        [UseApplicationDbContext]
        [UsePaging]
        public Task<List<Category>> GetCategories(
            [ScopedService] ApplicationDbContext context) =>
            context.Categories.OrderBy(t => t.Name).ToListAsync();

        [UseApplicationDbContext]
        public Task<Category> GetCategoryByNameAsync(
            string name,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            context.Categories.FirstAsync(t => t.Name == name);

        [UseApplicationDbContext]
        public async Task<IEnumerable<Category>> GetCategoriesByNamesAsync(
            string[] names,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken) =>
            await context.Categories.Where(t => names.Contains(t.Name)).ToListAsync();


        public Task<Category> GetCategoryByIdAsync(
            [ID(nameof(Category))] int id,
            CategoryByIdDataLoader categoryById,
            CancellationToken cancellationToken) =>
            categoryById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Category>> GetCategoriesByIdAsync(
            [ID(nameof(Category))] int[] ids,
            CategoryByIdDataLoader categoryById,
            CancellationToken cancellationToken) =>
            await categoryById.LoadAsync(ids, cancellationToken);
    }
}
