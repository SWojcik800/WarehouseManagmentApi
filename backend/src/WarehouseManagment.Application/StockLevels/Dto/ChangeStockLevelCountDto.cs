﻿namespace WarehouseManagment.Application.StockLevels.Dto
{
    public sealed class ChangeStockLevelCountDto
    {
        public long ProductId { get; set; }
        public long ProductsInStock { get; set; }
    }
}
