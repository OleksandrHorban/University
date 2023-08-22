using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

// Відобразити кількість покупців у кожному місті
internal class PrintCountBuyersInEachCity : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            db.Query<CountBuyersInEachCity>("EXEC CountBuyersInEachCity")
                .ToList() // результат запиту в форматі List<T>
                // По-елементно перебираю результат
                .ForEach(t => Console.WriteLine(t.Count + " " + t.NameCity));
        }

        return Task.CompletedTask;
    }
}

record class CountBuyersInEachCity(int Count, string NameCity);