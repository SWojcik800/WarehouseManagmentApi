using Microsoft.EntityFrameworkCore;
using WarehouseManagment.Infrastructure.Entities;

namespace WarehouseManagment.Infrastructure.Data
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IInfrastructureAssemblyMarker).Assembly);
        }

        internal DbSet<Shipment> Shipments { get; set; }
        internal DbSet<Product> Products { get; set; }

    }
}
