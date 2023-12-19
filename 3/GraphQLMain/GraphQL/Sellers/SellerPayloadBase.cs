using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Sellers
{
    public class SellerPayloadBase : Payload
    {
        protected SellerPayloadBase(Seller seller)
        {
            Seller = seller;
        }

        protected SellerPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Seller? Seller { get; }
    }
}
