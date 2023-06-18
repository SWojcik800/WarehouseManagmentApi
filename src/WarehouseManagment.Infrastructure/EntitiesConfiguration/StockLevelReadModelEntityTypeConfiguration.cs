using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagment.Core.StockLevels.ReadModels;

namespace WarehouseManagment.Infrastructure.EntitiesConfiguration
{
    internal class StockLevelReadModelEntityTypeConfiguration : IEntityTypeConfiguration<StockLevelReadModel>
    {
        public void Configure(EntityTypeBuilder<StockLevelReadModel> builder)
        {
            builder.HasNoKey().ToView("vw_StockLevelReadModels");
        }
    }
}
