namespace P01_BillsPaymentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.EntityConfig;
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Emit;

    public class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext() { }
        public BillsPaymentSystemContext(DbContextOptions options) : base(options) { }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BankAccountConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CreditCardConfiguration());
            builder.ApplyConfiguration(new PaymentMethodConfiguration());
        }
    }
}
