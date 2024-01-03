using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Buyer>()
                .HasIndex(b => b.UserName)
                .IsUnique();

            // Many-to-many: Event <-> Buyer
            modelBuilder
                .Entity<EventBuyer>()
                .HasKey(eb => new { eb.EventId, eb.BuyerId });

            // Many-to-many: Seller <-> Event
            modelBuilder
                .Entity<EventSeller>()
                .HasKey(es => new { es.EventId, es.SellerId });
        }

        public DbSet<Event> Events { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Seller> Sellers { get; set; } = default!;

        public DbSet<Buyer> Buyers { get; set; } = default!;

        // Додана властивість EventSellers
        public DbSet<EventSeller> EventSellers { get; set; } = default!;
    }
}
