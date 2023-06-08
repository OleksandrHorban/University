using System.Data.SqlClient;

namespace ForumDAL.Repositories
{
    public class Connection
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(@"Server=.\\SQLEXPRESS;Initial Catalog=CoinsProject;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;");
        }
    }
}
