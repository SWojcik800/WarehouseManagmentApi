using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagment.Core.Products;

namespace WarehouseManagment.Infrastructure.EntitiesConfiguration
{
    internal sealed class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(p => p.Name)
                .Property(p => p.Value)
                .HasColumnName("Name");
            builder.OwnsOne(p => p.Description)
                .Property(p => p.Value)
                .HasColumnName("Description");
            builder.OwnsOne(p => p.Manufacturer)
                .Property(p => p.Value)
                .HasColumnName("Manufacturer");
            builder.Property<bool>("_isDeleted")
                .HasColumnName("isDeleted");

            builder.HasQueryFilter(p => EF.Property<bool>(p, "_isDeleted") == false);                
        }
    }
}
