using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

// Показати найкраще місто за кількістю покупців
internal class PrintTopCityByCountBuyers : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            db.Query<TopCityByCountBuyers>("EXEC TopCityByCountBuyers")
                .ToList() // результат запиту в форматі List<T>
                // По-елементно перебираю результат
                .ForEach(t => Console.WriteLine($"{t.ID_City} {t.Name,-30} {t.ID_Country} {t.NumCount}"));

        }

        return Task.CompletedTask;
    }
}