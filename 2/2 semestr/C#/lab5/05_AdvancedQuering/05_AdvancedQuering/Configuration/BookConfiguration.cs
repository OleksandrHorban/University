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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(b => b.Description)
                .HasMaxLength(1000)
                .IsUnicode(true);

            builder.Property(b => b.EditionType)
                .HasConversion<string>();

            builder.Property(b => b.AgeRestriction)
                .HasConversion<string>();

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
            builder.HasData(Seeder.Books);
        }
    }
}