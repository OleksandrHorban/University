using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

// Відобразити кількість міст у кожній країні
internal class PrintCountCityInEachCountry : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            db.Query<CountCityInEachCountry>("EXEC CountCityInEachCountry")
                .ToList() // результат запиту в форматі List<T>
                // По-елементно перебираю результат
                .ForEach(t => Console.WriteLine(t.Count + " " + t.NameCountry));
        }

        return Task.CompletedTask;
    }
}

record class CountCityInEachCountry(int Count, string NameCountry);