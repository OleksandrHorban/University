using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Buyers
{
    public class RegisterBuyerPayload : BuyerPayloadBase
    {
        public RegisterBuyerPayload(Buyer buyer)
            : base(buyer)
        {
        }

        public RegisterBuyerPayload(UserError error)
            : base(new[] { error })
        {
        }
    }
}
