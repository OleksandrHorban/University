using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;

namespace ConferencePlanner.GraphQL.Tracks
{
    [ExtendObjectType("Mutation")]
    public class TrackMutations
    {
        [UseApplicationDbContext]
        public async Task<RenameTrackPayload> RenameTrackAsync(
     RenameTrackInput input,
     [ScopedService] ApplicationDbContext context,
     CancellationToken cancellationToken)
        {
            Track track = await context.Tracks.FindAsync(input.Id);
            track.Name = input.Name;

            await context.SaveChangesAsync(cancellationToken);

            return new RenameTrackPayload(track);
        }
    }
}