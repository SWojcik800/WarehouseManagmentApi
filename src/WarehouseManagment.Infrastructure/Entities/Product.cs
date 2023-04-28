namespace WarehouseManagment.Infrastructure.Entities
{
    internal sealed class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufactureraName { get; set; }
        public uint Count { get; set; }
        public Shipment Shipment { get; set; }
    }
}
