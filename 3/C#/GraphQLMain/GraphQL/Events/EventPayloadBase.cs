using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Events
{
    public class EventPayloadBase : Payload
    {
        protected EventPayloadBase(Event @event)
        {
            Event = @event;
        }

        protected EventPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Event? Event { get; }
    }
}



