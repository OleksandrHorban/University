using BookShop.Entities;
using BookShop.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);
            builder.HasData(Seeder.Authors);
        }
    }
}