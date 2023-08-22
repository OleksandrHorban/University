using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

internal class PRINT_MENU
{
    public static async Task Print(SqlConnection connection, IMenu item) => await item.Menu(connection);
}