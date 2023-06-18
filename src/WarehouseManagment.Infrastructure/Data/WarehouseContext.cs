using Microsoft.EntityFrameworkCore;
using WarehouseManagment.Core.Products;
using WarehouseManagment.Core.StockLevels.Entities;
using WarehouseManagment.Core.StockLevels.ReadModels;

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
        public DbSet<StockLevel> StockLevels { get; set; }
        private DbSet<StockLevelReadModel> _stockLevelReadModels;
        public IQueryable<StockLevelReadModel> StockLevelReadModels
            => _stockLevelReadModels.AsNoTracking();

    }
}
