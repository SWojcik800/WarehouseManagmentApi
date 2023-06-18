namespace WarehouseManagment.Core.StockLevels.Queries
{
    public sealed record GetPaginatedStockLevelListQuery(string? ProductName, string? ProductManufacturer, int Offset = 0, int Limit = 10)
    {

    }
}
