using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Seeding
{
    public class BillsCatalogSeeder : ISeeder<BillsCatalog>
    {
        private static readonly List<BillsCatalog> bills = new()
        {
            new BillsCatalog
            {
                BillID = 1,
                Name = "Name of bill 1",
                Country = "USA",
                GraduationYear = 1999,
                TypeOfSecurity = "watermark",
                Description = "Good bill from USA"
            }
        };

        public void Seed(EntityTypeBuilder<BillsCatalog> builder) => builder.HasData(bills);
    }
}
