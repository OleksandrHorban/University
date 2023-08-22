using Forum.BLL.Interfaces;
using Forum.BLL.Services;
using ForumDAL.Repositories;
using ForumDAL.Repositories.Contracts;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("MSSQLConnection")));
builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection conn = s.GetRequiredService<SqlConnection>();
    conn.Open();
    return conn.BeginTransaction();
});

builder.Services.AddScoped<IDiscussionRepository, DiscussionRepository>();
builder.Services.AddScoped<IDefinitionRepository, DefinitionRepository>();
builder.Services.AddScoped<IDisDefRepository, DisDefRepository>();
builder.Services.AddScoped<IDiscussionService, DiscussionService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
