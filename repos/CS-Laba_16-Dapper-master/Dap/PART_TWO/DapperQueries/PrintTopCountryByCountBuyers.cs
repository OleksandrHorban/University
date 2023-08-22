using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

// Показати найкращу країну за кількістю покупців
internal class PrintTopCountryByCountBuyers : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            db.Query<TopCountryByCountBuyers>("EXEC TopCountryByCountBuyers")
                .ToList() // результат запиту в форматі List<T>
                // По-елементно перебираю результат
                .ForEach(t => Console.WriteLine($"{t.ID_Country} {t.Name,-30} {t.NumCount}"));
        }

        return Task.CompletedTask;
    }
}