namespace WarehouseManagment.Application.Shipment.Dtos
{
    public sealed class ShipmentProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufactureraName { get; set; }
        public uint Count { get; set; }
    }
}
