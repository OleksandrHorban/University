using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Sellers
{
    public class AddSellerPayload : SellerPayloadBase
    {
        public AddSellerPayload(Seller seller)
            : base(seller)
        {
        }

        public AddSellerPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
