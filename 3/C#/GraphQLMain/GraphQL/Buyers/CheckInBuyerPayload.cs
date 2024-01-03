using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;

namespace ConferencePlanner.GraphQL.Buyers
{
    public class CheckInBuyerPayload : BuyerPayloadBase
    {
        private int? _eventId;

        public CheckInBuyerPayload(Buyer buyer, int eventId)
            : base(buyer)
        {
            _eventId = eventId;
        }

        public CheckInBuyerPayload(UserError error)
            : base(new[] { error })
        {
        }

        public async Task<Event?> GetEventAsync(
            EventByIdDataLoader eventById,
            CancellationToken cancellationToken)
        {
            if (_eventId.HasValue)
            {
                return await eventById.LoadAsync(_eventId.Value, cancellationToken);
            }

            return null;
        }
    }
}
