using System.Collections.Generic;
using ConferencePlanner.GraphQL.Data;
using HotChocolate.Types.Relay;

namespace ConferencePlanner.GraphQL.Events
{
    public record AddEventInput(
        string Title,
        string? Abstract,
        [ID(nameof(Seller))]
        IReadOnlyList<int> SellerIds);
}
