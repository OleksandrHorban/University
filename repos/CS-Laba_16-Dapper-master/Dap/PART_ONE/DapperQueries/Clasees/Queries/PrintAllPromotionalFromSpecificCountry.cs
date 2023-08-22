using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal class PrintAllPromotionalFromSpecificCountry : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            Console.Write("Введіть назву країни: ");
            string? country = Console.ReadLine();

            var result = db.Query<PromotionalProducts>
                (
                    "SELECT A.[ID акції] AS ID_Stock," +
                    "A.[Назва товару] AS NameProduct," +
                    "A.[ID розділу] AS ID_Section," +
                    "A.[Дата початку] AS StartTime," +
                    "A.[Дата кінця] AS EndTime" +
                    " FROM [Акційні товари] A, [Акції_Країни] B, [Країни] C" +
                    " WHERE A.[ID акції] = B.[ID акції] AND B.[ID країни] = C.[ID країни] AND C.[Назва країни] = @Country",
                    new { Country = country?.Trim() }
                ).ToList();

            foreach (var item in result)
                Console.WriteLine($"{item.ID_Stock} {item.NameProduct, -100} {item.ID_Section} {item.StartTime[..10]} {item.EndTime[..10]}");
        }

        return Task.CompletedTask;
    }
}