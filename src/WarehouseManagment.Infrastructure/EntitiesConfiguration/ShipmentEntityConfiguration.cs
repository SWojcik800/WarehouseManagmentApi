using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagment.Infrastructure.Entities;

namespace WarehouseManagment.Infrastructure.EntitiesConfiguration
{
    internal sealed class ShipmentEntityConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasMany(x => x.Products);
        }
    }
}
