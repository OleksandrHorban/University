using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;

namespace EFCollections.DAL.Seeding
{
    public class CoinsCatalogSeeder : ISeeder<CoinsCatalog>
    {
        private static readonly List<CoinsCatalog> coins = new()
        {
            new CoinsCatalog
            {
                CoinId = 1,
                Name = "Coin Name 1",
                Country = "Ukraine",
                GraduationYear = 1980,
                Par = 10000,
                Description = "Good coin with good history"
            }
        };

        public void Seed(EntityTypeBuilder<CoinsCatalog> builder) => builder.HasData(coins);
    }
}
