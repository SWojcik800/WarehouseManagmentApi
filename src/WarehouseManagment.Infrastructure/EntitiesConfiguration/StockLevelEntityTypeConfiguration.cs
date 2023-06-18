using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagment.Core.Products;
using WarehouseManagment.Core.StockLevels.Entities;

namespace WarehouseManagment.Infrastructure.EntitiesConfiguration
{
    internal class StockLevelEntityTypeConfiguration : IEntityTypeConfiguration<StockLevel>
    {
        public void Configure(EntityTypeBuilder<StockLevel> builder)
        {
            builder.HasOne<Product>()
                .WithOne()
                .HasForeignKey(nameof(StockLevel), nameof(StockLevel.ProductId));

            builder.OwnsOne(s => s.Count)
                .Property(c => c.Value)
                .HasColumnName(nameof(StockLevel.Count));
                
        }
    }
}
