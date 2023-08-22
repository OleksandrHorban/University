using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

// Відобразити середню кількість міст по всіх країнах
internal class PrintAVGCountCityInAllCountry : IQuery
{
    public async Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            var cmd = new SqlCommand()
            {
                Connection = connection,
                CommandText = "AVGCountCityInAllCountry",
                CommandType = CommandType.StoredProcedure
            };

            var param = new SqlParameter // OUTPUT параметр кількість міст
            {
                ParameterName = "@City",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(param);
            param = new SqlParameter // OUTPUT параметр кількість країн
            {
                ParameterName = "@Country",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(param);

            await cmd.ExecuteNonQueryAsync();


            var City = (double)cmd.Parameters["@City"].Value; //  кількість міст
            var Country = (double)cmd.Parameters["@Country"].Value; //  кількість країн

            Console.WriteLine("Середня кількість міст по всіх країнах: " + (City / Country));
        }
    }
}