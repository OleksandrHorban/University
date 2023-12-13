using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace ConferencePlanner.GraphQL.Sessions
{
    [ExtendObjectType("Mutation")]
    public class SessionMutations
    {
        [UseApplicationDbContext]
        public async Task<ScheduleSessionPayload> ScheduleSessionAsync(
    ScheduleSessionInput input,
    [ScopedService] ApplicationDbContext context,
    [Service] ITopicEventSender eventSender)
        {
            if (input.EndTime < input.StartTime)
            {
                return new ScheduleSessionPayload(
                    new UserError("endTime has to be larger than startTime.", "END_TIME_INVALID"));
            }

            Session session = await context.Sessions.FindAsync(input.SessionId);

            if (session is null)
            {
                return new ScheduleSessionPayload(
                    new UserError("Session not found.", "SESSION_NOT_FOUND"));
            }

            session.TrackId = input.TrackId;
            session.StartTime = input.StartTime;
            session.EndTime = input.EndTime;

            await context.SaveChangesAsync();

            await eventSender.SendAsync(
                nameof(SessionSubscriptions.OnSessionScheduledAsync),
                session.Id);

            return new ScheduleSessionPayload(session);
        }
    }
}
