using ForumDAL.Entities;
using ForumDAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ForumDAL.Repositories
{
    public class DiscussionRepository : GenericRepository<Discussion>, IDiscussionRepository
    {
        public DiscussionRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Discussion")
        {
        }

        public async Task<IEnumerable<Definition>>GetAllDefinitionByDiscussionIdAsync(int id)
        {
            return await _sqlConnection.QueryAsync<Definition>($"SELECT * " +
                $"FROM Discussion AS P " +
                $"JOIN DisDef AS PT ON P.Id = PT.DiscussionId " +
                $"JOIN Definition AS T ON PT.DefinitionId = T.Id " +
                $"WHERE P.Id = @Id",
                param: new { Id = id },
                transaction: _dbTransaction);
        }
        public new async Task DeleteAsync(int id)
        {
            await _sqlConnection.ExecuteAsync($"DELETE FROM DisDef where DiscussionId=@Id " +
                $"DELETE FROM Discussion WHERE Id=@Id",
               param: new { Id = id },
               transaction: _dbTransaction);
        }
    }
}
