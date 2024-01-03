using ConferencePlanner.GraphQL.Data;
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Categories
{
    public record RenameCategoryInput([ID(nameof(Category))] int Id, string Name);
}
