using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal class PrintAllBuyers : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            var result = db.Query<Buyer>(
                "SELECT [ID покупця] AS ID_Buyer," +
                "[ПІБ] AS Name," +
                "[Дата народження] AS Birthday," +
                "[Email] AS Email," +
                "[ID країни] AS ID_Country," +
                "[ID міста] AS ID_City " +
                "FROM [Покупці]"
                ).ToList();
            
            foreach (var item in result)
                Console.WriteLine($"{item.ID_Buyer} {item.Name, -50} {item.Birthday[..10]} {item.Email, -50} {item.ID_Country} {item.ID_City}");
        }

        return Task.CompletedTask;
    }
}