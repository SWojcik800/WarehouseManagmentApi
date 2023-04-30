namespace WarehouseManagment.Application.Shipment.Dtos
{
    public sealed class CreateShipmentDto
    {
        public IReadOnlyList<CreateShipmentProductDto> Products { get; set; }
        public DateTime ShipmentArrived { get; set; }
    }
}
