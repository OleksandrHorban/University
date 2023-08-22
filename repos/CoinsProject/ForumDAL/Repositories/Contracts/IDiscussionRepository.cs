using ForumDAL.Entities;

namespace ForumDAL.Repositories.Contracts
{
    public interface IDiscussionRepository : IGenericRepository<Discussion>
    {
        Task<IEnumerable<Definition>> GetAllDefinitionByDiscussionIdAsync(int id);
    }
}
