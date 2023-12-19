using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Buyers
{
    public class BuyerPayloadBase : Payload
    {
        protected BuyerPayloadBase(Buyer buyer)
        {
            Buyer = buyer;
        }

        protected BuyerPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Buyer? Buyer { get; }
    }
}
