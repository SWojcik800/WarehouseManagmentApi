using WarehouseManagment.Common.Exceptions;

namespace WarehouseManagment.Core.Products
{
    public sealed record ProductName
    {
        public string Value { get; private set; }
        public ProductName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationException("Cannot add product with empty name");

            Value = value;
        }

        public static implicit operator string(ProductName obj)
            => obj.Value;

        public static implicit operator ProductName(string value)
            => new ProductName(value);
    }
}
