using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal class PrintAllCountries : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            var result = db.Query<Countries>(
                "SELECT [ID країни] AS ID_Country," +
                "[Назва країни] AS Name" +
                " FROM [Країни]" +
                " ORDER BY [ID країни],[Назва країни]"
                ).ToList();

            foreach (var item in result)
                Console.WriteLine($"{item.ID_Country} {item.Name,-30}");
        }

        return Task.CompletedTask;
    }
}