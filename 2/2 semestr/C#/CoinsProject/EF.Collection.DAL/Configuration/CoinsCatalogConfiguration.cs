using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Seeding;

namespace EFCollections.DAL.Configuration
{
    public class CoinsCatalogConfiguration : IEntityTypeConfiguration<CoinsCatalog>
    {
        public void Configure(EntityTypeBuilder<CoinsCatalog> builder)
        {
            builder.Property(coins => coins.CoinId)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(coins => coins.Name)
                   .HasMaxLength(50)
                   .IsRequired(); 
            builder.Property(coins => coins.Country)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(coins => coins.GraduationYear)
                .IsRequired();
            builder.Property(coins => coins.Par)
                .IsRequired();
            builder.Property(coins => coins.Description)
                .HasMaxLength(100)
                .IsRequired();

            new CoinsCatalogSeeder().Seed(builder);
        }
    }
}
