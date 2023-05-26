namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(e => e.BankAccountId);
            builder.Property(e => e.BankName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();
            builder.Property(e => e.SwiftCode)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Ignore(e => e.PaymentMethodId);

        }
    }
}
