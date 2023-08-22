using Microsoft.EntityFrameworkCore;
using EFCollections.DAL.Entities;
using EFCollections.DAL.Configuration;

namespace EFCollections.DAL.Data
{ 
    public class CatalogContext : DbContext 
    {
        public DbSet<CoinsCatalog> CoinsCatalog { get; set; }
        public DbSet<BillsCatalog> BillsCatalog { get; set; }
        public DbSet<AnotherCatalog> AnotherCatalog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CoinsCatalogConfiguration());
            modelBuilder.ApplyConfiguration(new BillsCatalogConfiguration());
            modelBuilder.ApplyConfiguration(new AnotherCatalogConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=CoinsProject2;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;");
            }
        }

        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }
    }
}
