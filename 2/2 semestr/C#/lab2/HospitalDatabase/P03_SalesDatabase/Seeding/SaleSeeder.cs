using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Interfaces;
using P03_SalesDatabase.Data.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Seeding
{
    public class SaleSeeder : ISeeder<Sale>
    {
        public void Seed(EntityTypeBuilder<Sale> builder)
        {
            var id = 1;

            var faker = new Faker<Sale>()
                .RuleFor(e => e.SaleId, f => id++)
                .RuleFor(e => e.Date, f => f.Date.Past())
                .RuleFor(e => e.CustomerId, f => f.Random.Number(1, 10))
                .RuleFor(e => e.ProductId, f => f.Random.Number(1, 10))
                .RuleFor(e => e.StoreId, f => f.Random.Number(1, 10));

            var s = faker.Generate(10);
            builder.HasData(s);
        }
    }
}
