using WarehouseManagment.Common.Exceptions;

namespace WarehouseManagment.Core.Products
{
    public sealed record ProductManufacturer
    {
        public string Value { get; private set; }
        public ProductManufacturer(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationException("Cannot add product without manufacturer");

            Value = value;
        }

        public static implicit operator string(ProductManufacturer obj)
            => obj.Value;

        public static implicit operator ProductManufacturer(string value)
            => new ProductManufacturer(value);
    }
}
