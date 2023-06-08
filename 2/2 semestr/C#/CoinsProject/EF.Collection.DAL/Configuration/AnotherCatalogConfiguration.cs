using EFCollections.DAL.Seeding;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EFCollections.DAL.Entities;

namespace EFCollections.DAL.Configuration
{
    public class AnotherCatalogConfiguration : IEntityTypeConfiguration<AnotherCatalog>
    {
        public void Configure(EntityTypeBuilder<AnotherCatalog> builder)
        {
            builder.Property(another => another.AnotherID)
                   .IsRequired();

            builder.Property(another => another.Name)
                .HasMaxLength(50)
                   .IsRequired();
            builder.Property(another => another.Type)
                .HasMaxLength(50)
                   .IsRequired();
            builder.Property(another => another.Location)
                .HasMaxLength(50)
                   .IsRequired();
            builder.Property(another => another.Description)
                .HasMaxLength(100)
                   .IsRequired();

            new AnotherCatalogSeeder().Seed(builder);
        }
    }
}
