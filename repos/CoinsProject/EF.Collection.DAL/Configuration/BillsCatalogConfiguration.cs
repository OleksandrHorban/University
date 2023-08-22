using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Seeding;

namespace EFCollections.DAL.Configuration
{
    public class BillsCatalogConfiguration : IEntityTypeConfiguration<BillsCatalog>
    {
        public void Configure(EntityTypeBuilder<BillsCatalog> builder)
        {
            builder.Property(bills => bills.BillID)
                   .IsRequired();

            builder.Property(bills => bills.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(bills => bills.Country)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(bills => bills.GraduationYear)
               .IsRequired();
            builder.Property(bills => bills.TypeOfSecurity)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(bills => bills.Description)
                   .HasMaxLength(100)
                   .IsRequired();
            new BillsCatalogSeeder().Seed(builder);
        }
    }
}
