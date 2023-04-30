using WarehouseManagment.Application.Shipment.Dtos;

namespace WarehouseManagment.Application.Shipment
{
    public interface IShipmentService
    {
        Task<List<ShipmentDto>> GetCurrentShipments();
        Task IssueShipment(long shipmentId, string shipmentIssuedTo);
        Task RegisterIncomingShipment(CreateShipmentDto dto);
    }
}