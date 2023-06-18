using WarehouseManagment.Common.Entity;

namespace WarehouseManagment.Core.Products
{
    public sealed class Product : EntityBase
    {
        private Product()
        {
            //For Ef Core
        }

        private Product(ProductName name, ProductDescription description, ProductManufacturer manufacturer)
        {
            Name = name;
            Description = description;
            Manufacturer = manufacturer;
        }

        public static Product Create(ProductName name, ProductDescription description, ProductManufacturer manufacturer)
            => new Product(name, description, manufacturer);

        public ProductName Name { get; set; }
        public ProductDescription Description { get; set; }
        public ProductManufacturer Manufacturer { get; set; }

        public void Delete()
            => _isDeleted = true;

        private bool _isDeleted;
    }
}
