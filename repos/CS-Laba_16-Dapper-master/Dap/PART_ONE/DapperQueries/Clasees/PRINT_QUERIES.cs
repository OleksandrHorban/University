using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal class PRINT_QUERIES
{
    public static async Task Print(IQuery query, SqlConnection connection) => await query.Print(connection);
}