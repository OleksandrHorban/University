using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Subscriptions;

namespace ConferencePlanner.GraphQL.Buyers
{
    [ExtendObjectType(Name = "Mutation")]
    public class BuyerMutations
    {
        [UseApplicationDbContext]
        public async Task<RegisterBuyerPayload> RegisterBuyerAsync(
            RegisterBuyerInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var buyer = new Buyer
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName,
                EmailAddress = input.EmailAddress
            };

            context.Buyers.Add(buyer);

            await context.SaveChangesAsync(cancellationToken);

            return new RegisterBuyerPayload(buyer);
        }

        [UseApplicationDbContext]
        public async Task<CheckInBuyerPayload> CheckInBuyerAsync(
            CheckInBuyerInput input,
            [ScopedService] ApplicationDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            Buyer buyer = await context.Buyers.FirstOrDefaultAsync(
                t => t.Id == input.BuyerId, cancellationToken);

            if (buyer is null)
            {
                return new CheckInBuyerPayload(
                    new UserError("Buyer not found.", "BUYER_NOT_FOUND"));
            }

            buyer.EventsBuyers.Add(
                new EventBuyer
                {
                    EventId = input.EventId
                });

            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(
                "OnBuyerCheckedIn_" + input.EventId,
                input.BuyerId,
                cancellationToken);

            return new CheckInBuyerPayload(buyer, input.EventId);
        }
    }
}
