using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal class PrintAllPromotionalProducts : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            var result = db.Query<PromotionalProducts>(
                        "SELECT [ID акції] AS ID_Stock," +
                        "[Назва товару] AS NameProduct," +
                        "[ID розділу] AS ID_Section," +
                        "[Дата початку] AS StartTime," +
                        "[Дата кінця] AS EndTime" +
                        " FROM [Акційні товари]"
                        ).ToList();

            foreach (var item in result)
                Console.WriteLine($"{item.ID_Stock} {item.NameProduct, -100} {item.ID_Section} {item.StartTime[..10]} {item.EndTime[..10]}");
        }

        return Task.CompletedTask;
    }
}