namespace ForumDAL.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IDiscussionRepository _discussionRepository { get; }
        IDefinitionRepository _definitionRepository { get; }
        IDisDefRepository _disdefRepository { get; }
        void Commit();
        void Dispose();
    }
}
