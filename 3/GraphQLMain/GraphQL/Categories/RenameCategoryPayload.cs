using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Categories
{
    public class RenameCategoryPayload : CategoryPayloadBase
    {
        public RenameCategoryPayload(Category category)
            : base(category)
        {
        }

        public RenameCategoryPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}

