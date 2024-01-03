using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Events
{
    public class AddEventPayload : EventPayloadBase
    {
        public AddEventPayload(UserError error)
            : base(new[] { error })
        {
        }

        public AddEventPayload(Event events) : base(events)
        {
        }

        public AddEventPayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }
}

