using ForumDAL.Repositories.Contracts;
using System.Data;

namespace ForumDAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IDiscussionRepository _discussionRepository { get; }
        public IDefinitionRepository _definitionRepository { get; }
        public IDisDefRepository _disdefRepository { get; }

        readonly IDbTransaction _dbTransaction;

        public UnitOfWork(
            IDiscussionRepository discussionRepository,
            IDefinitionRepository definitionRepository,
            IDisDefRepository disdefRepository,
            IDbTransaction dbTransaction)
        {
            _discussionRepository= discussionRepository;
            _definitionRepository= definitionRepository;
            _disdefRepository= disdefRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
                // By adding this we can have muliple transactions as part of a single request
                //_dbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}