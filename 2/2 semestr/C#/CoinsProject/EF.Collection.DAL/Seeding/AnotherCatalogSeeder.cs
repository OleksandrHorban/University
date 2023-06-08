using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class AnotherCatalogSeeder : ISeeder<AnotherCatalog>
    {
        private static readonly List<AnotherCatalog> another = new()
        {
            new AnotherCatalog
            {
                AnotherID = 1,
                Name = "Something another 1",
                Type = "subject of war",
                Location = "battlefield in Lviv",
                Description = "description of interesting thing from the war",
            }
        };

        public void Seed(EntityTypeBuilder<AnotherCatalog> builder) => builder.HasData(another);
    }
}
