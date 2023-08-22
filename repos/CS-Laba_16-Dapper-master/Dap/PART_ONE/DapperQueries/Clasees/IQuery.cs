using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

internal interface IQuery
{
    Task Print(SqlConnection connection);
}