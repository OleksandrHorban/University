using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal class PrintAllBuyersFromSpecificCity : IQuery
{
    public Task Print(SqlConnection connection)
    {

        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            Console.Write("Введіть назву містa: ");
            string? city = Console.ReadLine();
            Console.WriteLine(city);

            var result = db.Query<Buyer>(
                "SELECT B.[ID покупця] AS ID_Buyer," +
                "       B.[ПІБ] AS Name," +
                "       B.[Дата народження] AS Birthday," +
                "       B.[Email] AS Email," +
                "       B.[ID країни] AS ID_Country," +
                "       B.[ID міста] AS ID_City" +
                " FROM [Покупці] B,[Міста] C" +
                " WHERE B.[ID міста] = C.[ID міста] AND C.[Назва міста] = @city ",
                new { city }
                ).ToList();

            foreach (var item in result)
                Console.WriteLine($"{item.ID_Buyer} {item.Name,-50} {item.Birthday[..10]} {item.Email,-50} {item.ID_Country} {item.ID_City}");
        }

        return Task.CompletedTask;
    }
}