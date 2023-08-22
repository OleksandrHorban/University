using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal class PrintAllProductsSections : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            var result = db.Query<ProductsSections>(
                "SELECT [ID розділу] AS ID_Section," +
                "[Назва розділу] AS NameSection " +
                " FROM [Розділи товарів]" +
                " ORDER BY [ID розділу],[Назва розділу]"
                ).ToList();
            
            foreach (var item in result)
                Console.WriteLine($"{item.ID_Section} {item.NameSection, -50}");
        }

        return Task.CompletedTask;
    }
}