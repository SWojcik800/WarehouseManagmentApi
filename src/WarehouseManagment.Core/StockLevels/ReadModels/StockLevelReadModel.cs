namespace WarehouseManagment.Core.StockLevels.ReadModels
{
    public sealed class StockLevelReadModel
    {
        public long StockLevelId { get; set; }
        public long ProductsInStock { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductManufacturer { get; set; }
    }
}
