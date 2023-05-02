using Microsoft.EntityFrameworkCore;
using WarehouseManagment.Core.Products;

namespace WarehouseManagment.Infrastructure.Data
{
    public sealed class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IInfrastructureAssemblyMarker).Assembly);
        }

        public DbSet<Product> Products { get; set; }

    }
}
