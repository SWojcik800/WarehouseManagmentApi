using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StockLevelReadModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create view vw_StockLevelReadModels
                as (
                select p.Id as ProductId,
                p.Name as ProductName,
                p.Manufacturer as ProductManufacturer,
                coalesce(slevels.Count, 0) as ProductsInStock
                from Products p
                left join StockLevels slevels on slevels.ProductId = p.Id
                where p.isDeleted = 0
                )
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                drop view vw_StockLevelReadModels
            ");
        }
    }
}
