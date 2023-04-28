using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagment.Infrastructure.Entities;

namespace WarehouseManagment.Infrastructure.EntitiesConfiguration
{
    internal sealed class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.Shipment);
        }
    }
}
