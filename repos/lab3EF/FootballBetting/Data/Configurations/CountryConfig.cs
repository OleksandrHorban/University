﻿using FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.Configurations
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.CountryId);
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsFixedLength(false)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .HasMany(c => c.Towns)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.TownId);
        }
    }
}
