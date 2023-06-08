using EFCollections.DAL.Data;
using EFCollections.DAL.Interfaces.Repositories;
using EFCollections.DAL.Data.Repositories;
using EFCollections.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CatalogContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
});

builder.Services.AddScoped<ICoinsCatalogRepository, CoinsCatalogRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
