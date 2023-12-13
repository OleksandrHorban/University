﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using ConferencePlanner.GraphQL.Sessions;
using ConferencePlanner.GraphQL.DataLoader;
using ConferencePlanner.GraphQL.Types;

namespace ConferencePlanner.GraphQL.Sessions
{
    [ExtendObjectType("Query")]
    public class SessionQueries
    {
        [UseApplicationDbContext]
        [UsePaging(typeof(NonNullType<SessionType>))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Session> GetSessions(
    [ScopedService] ApplicationDbContext context) =>
    context.Sessions;

        public Task<Session> GetSessionByIdAsync(
            [ID(nameof(Session))] int id,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken) =>
            sessionById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Session>> GetSessionsByIdAsync(
            [ID(nameof(Session))] int[] ids,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken) =>
            await sessionById.LoadAsync(ids, cancellationToken);
    }
}
