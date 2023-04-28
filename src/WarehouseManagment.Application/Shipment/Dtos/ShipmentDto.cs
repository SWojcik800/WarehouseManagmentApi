namespace WarehouseManagment.Application.Shipment.Dtos
{
    public sealed class ShipmentDto
    {
        public long Id { get; set; }
        public IReadOnlyList<ShipmentProductDto> Products { get; set; }
        public DateTime ShipmentArrived { get; set; }
    }
}
