using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.Events;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace ConferencePlanner.GraphQL.Events
{
    [ExtendObjectType("Mutation")]
    public class EventMutations
    {
        [UseApplicationDbContext]
        public async Task<ScheduleEventPayload> ScheduleEventAsync(
            ScheduleEventInput input,
            [ScopedService] ApplicationDbContext context,
            [Service] ITopicEventSender eventSender)
        {
            if (input.EndTime < input.StartTime)
            {
                return new ScheduleEventPayload(
                    new UserError("endTime has to be larger than startTime.", "END_TIME_INVALID"));
            }

            Event @event = new();
    /*        if (@event is null)
            {
                return new ScheduleEventPayload(
                    new UserError("Event not found.", "EVENT_NOT_FOUND"));
            }*/
            @event.Title = "";
            @event.CategoryId = input.CategoryId;
            @event.StartTime = input.StartTime;
            @event.EndTime = input.EndTime;
            context.Events.Add(@event);
            

            await eventSender.SendAsync(
                nameof(EventSubscriptions.OnEventScheduledAsync),
                @event.Id);
            await context.SaveChangesAsync(default);

            return new ScheduleEventPayload(@event);
        }
    }
}

