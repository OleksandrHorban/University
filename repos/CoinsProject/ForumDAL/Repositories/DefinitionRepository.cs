using System.Data.SqlClient;
using System.Data;
using ForumDAL.Entities;
using ForumDAL.Repositories.Contracts;
using Dapper;

namespace ForumDAL.Repositories
{
    public class DefinitionRepository : GenericRepository<Definition>, IDefinitionRepository
    {
        public DefinitionRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Definition")
        {

        }
        public new async Task DeleteAsync(int id)
        {
            await _sqlConnection.ExecuteAsync($"DELETE FROM DisDef where DefinitionId=@Id " +
                $"DELETE FROM Definition WHERE Id=@Id",
               param: new { Id = id },
               transaction: _dbTransaction);
        }
    }
}
