using WarehouseManagment.Common.Entity;
using WarehouseManagment.Core.StockLevels.ValueObjects;

namespace WarehouseManagment.Core.StockLevels.Entities
{
    public sealed class StockLevel : EntityBase
    {
        private StockLevel()
        {
            //For EF Core
        }

        private StockLevel(long productId, StockLevelCount count)
        {
            ProductId = productId;
            Count = count;
        }

        public static StockLevel Create(long productId, StockLevelCount count)
            => new StockLevel(productId, count);

        public long ProductId { get; private set; }
        public StockLevelCount Count { get; private set; }

        public StockLevelCount Increase(long increaseBy)
            => Count += increaseBy;
        public StockLevelCount Decrease(long decreaseBy)
            => Count -= decreaseBy;
    }
}
