using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

internal interface IMenu
{
    Task Menu(SqlConnection connection);
}