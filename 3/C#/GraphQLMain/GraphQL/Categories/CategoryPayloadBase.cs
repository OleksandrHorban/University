using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Categories
{
    public class CategoryPayloadBase : Payload
    {
        public CategoryPayloadBase(Category category)
        {
            Category = category;
        }

        public CategoryPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Category? Category { get; }
    }
}
