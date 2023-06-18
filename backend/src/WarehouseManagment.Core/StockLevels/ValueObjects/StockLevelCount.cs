using WarehouseManagment.Common.Exceptions;

namespace WarehouseManagment.Core.StockLevels.ValueObjects
{
    public sealed record StockLevelCount
    {
        public long Value { get; private set; }

        public StockLevelCount(long value)
        {
            if (value < 0)
                throw new ValidationException("Stock level cannot be below 0");

            Value = value;
        }

        public static implicit operator long(StockLevelCount stockLevelCount)
            => stockLevelCount.Value;

        public static implicit operator StockLevelCount(long value)
            => new StockLevelCount(value);
    }
}
