using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Categories
{
    public class AddCategoryPayload : CategoryPayloadBase
    {
        public AddCategoryPayload(Category category)
            : base(category)
        {
        }

        public AddCategoryPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
