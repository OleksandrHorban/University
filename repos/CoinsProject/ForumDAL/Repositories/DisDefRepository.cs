using ForumDAL.Entities;
using ForumDAL.Repositories.Contracts;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace ForumDAL.Repositories
{
    public class DisDefRepository : GenericRepository<DisDef>, IDisDefRepository
    {
        public DisDefRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "DisDef")
        {

        }

    }
}
