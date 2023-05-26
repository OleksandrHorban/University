using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FootballBetting.Data.Models;

namespace FootballBetting.Data.Configurations
{
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(c => c.ColorId);
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsFixedLength(true)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .HasMany(c => c.PrimaryKitTeams)
                .WithOne(c => c.PrimaryKitColor)
                .HasForeignKey(c => c.PrimaryKitColorId);
            builder
                .HasMany(c => c.SecondaryKitTeams)
                .WithOne(c => c.SecondaryKitColor)
                .HasForeignKey(c => c.SecondaryKitColorId);
        }
    }
}