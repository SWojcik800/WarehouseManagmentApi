using WarehouseManagment.Core.Exceptions;

namespace WarehouseManagment.Core.Products
{
    public sealed record ProductDescription
    {
        public string Value { get; private set; }
        public ProductDescription(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Cannot add product with empty description");

            Value = value;
        }

        public static implicit operator string(ProductDescription obj)
            => obj.Value;

        public static implicit operator ProductDescription(string value)
            => new ProductDescription(value);
    }
}
