using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal class PrintAllCities : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            var result = db.Query<Cities>(
                "SELECT [ID міста] AS ID_City," +
                "[Назва міста] AS NameCity," +
                "[ID країни] AS ID_Country" +
                " FROM [Міста]"
                ).ToList();

            foreach (var item in result)
                Console.WriteLine($"{item.ID_City} {item.NameCity,-30} {item.ID_Country}");
        }

        return Task.CompletedTask;
    }
}