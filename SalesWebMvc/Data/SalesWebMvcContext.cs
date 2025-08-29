using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = null!;
        public DbSet<Seller> Seller { get; set; } = null!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = null!;

        // Aqui você customiza o mapeamento do EF
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Força Id como Identity(1,1) no SQL Server
            modelBuilder.Entity<Department>()
                .Property(p => p.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Seller>()
                .Property(p => p.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<SalesRecord>()
                .Property(p => p.Id)
                .UseIdentityColumn();
        }
    }
}
