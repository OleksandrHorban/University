using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

// Відобразити топ-3 країн за кількістю покупців
internal class PrintTopThreeCountryByCountBuyers : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            db.Query<TopCountryByCountBuyers>("EXEC TopThreeCountryByCountBuyers")
                .ToList() // результат запиту в форматі List<T>
                // По-елементно перебираю результат
                .ForEach(t => Console.WriteLine($"{t.ID_Country} {t.Name, -30} {t.NumCount}"));
        }

        return Task.CompletedTask;
    }
}

record class TopCountryByCountBuyers(int ID_Country, string Name, int NumCount);