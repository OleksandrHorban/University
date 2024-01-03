using ConferencePlanner.GraphQL.Data;
using HotChocolate.Data.Filters;

namespace ConferencePlanner.GraphQL.Types
{
    public class EventFilterInputType : FilterInputType<Event>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Event> descriptor)
        {
            descriptor.Ignore(t => t.Id);
            descriptor.Ignore(t => t.CategoryId);
        }
    }
}
