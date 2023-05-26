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
    public class StoreSeeder : ISeeder<Store>
    {
        public void Seed(EntityTypeBuilder<Store> builder)
        {
            var id = 1;

            var faker = new Faker<Store>()
                .RuleFor(e => e.StoreId, f => id++)
                .RuleFor(e => e.Name, f => f.Company.CompanyName());

            var st = faker.Generate(10);
            builder.HasData(st);
        }
    }
}
