using System;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace MVVM_Pet_2
{
    public partial class VetClinic_DB_MsSQLContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public VetClinic_DB_MsSQLContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=VetClinic_DB_MsSQL;Trusted_Connection=true");
        }
    }
}
