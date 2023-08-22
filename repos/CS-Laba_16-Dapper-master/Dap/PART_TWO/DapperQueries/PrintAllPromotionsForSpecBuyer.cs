using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

// Відобразити всі акційні товари для конкретного покупця
internal class PrintAllPromotionsForSpecBuyer : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            Console.Write("Введіть ім'я покупця: ");
            string? name = Console.ReadLine();
            Console.WriteLine();

            db.Query<PromotionalProducts> // виклик процедури
            (
                "AllPromotionsForSpecBuyer", // назва процедури
                new // параметри для процедури
                {
                    Name = name
                },
                commandType: CommandType.StoredProcedure // тип команди збережувана процедура
            )
            .ToList() // результат запиту в форматі List<T>
            // По-елементно перебираю результат
            .ForEach(t => Console.WriteLine($"{t.ID_Stock} {t.NameProduct,-100} {t.ID_Section} {t.StartTime[..10]} {t.EndTime[..10]}"));
        }

        return Task.CompletedTask;
    }
}