namespace WarehouseManagment.Application.StockLevels.Dto
{
    public sealed class CreateStockLevelDto
    {
        public long ProductId { get; set; }
        public long Count { get; set; }
    }
}
