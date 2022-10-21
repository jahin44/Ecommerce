using Ecommerce.ServiceLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.ServiceLayer.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
              .HasKey(O => O.Id);

            modelBuilder.Entity<OrderDetails>()
                .HasKey(OD => OD.Id);

            modelBuilder.Entity<OrderDetails>()
              .HasOne(OD => OD.Order)
              .WithMany(O => O.OrderDetails)
              .HasForeignKey(OD => OD.OrderId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
