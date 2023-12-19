using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Buyers
{
    [ExtendObjectType(Name = "Subscription")]
    public class BuyerSubscriptions
    {
        [Subscribe(With = nameof(SubscribeToOnBuyerCheckedInAsync))]
        public EventBuyerCheckIn OnBuyerCheckedIn(
            [ID(nameof(Event))] int eventId,
            [EventMessage] int buyerId) =>
            new EventBuyerCheckIn(buyerId, eventId);

        public async ValueTask<ISourceStream<int>> SubscribeToOnBuyerCheckedInAsync(
            int eventId,
            [Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken) =>
            await eventReceiver.SubscribeAsync<int>("OnBuyerCheckedIn_" + eventId, cancellationToken);
    }
}
