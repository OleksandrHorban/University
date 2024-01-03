using System;
using ConferencePlanner.GraphQL.Data;
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Events
{
    public record ScheduleEventInput(
        [ID(nameof(Event))]
        int EventId,
        [ID(nameof(Category))]
        int CategoryId,
        DateTimeOffset StartTime,
        DateTimeOffset EndTime);
}
